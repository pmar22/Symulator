using Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symulator
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private List<Test> _selectedTests;
        private bool _exportToExcel;
        private bool _showChart;
        private Test _selectedPredefineTest;

        #endregion

        #region INotifyPropertyCHnaged

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public bool ExportToExcel
        {
            get { return _exportToExcel; }
            set
            {
                _exportToExcel = value;
                OnPropertyChanged("ExportToExcel");
            }
        }

        public bool ShowChart
        {
            get { return _showChart; }
            set
            {
                _showChart = value;
                OnPropertyChanged("ShowChart");
            }
        }

        public ObservableCollection<Test> Tests { get; set; }

        public List<Test> SelectedTests
        {
            get { return _selectedTests; }
            set
            {
                _selectedTests = value;
                OnPropertyChanged("SelectedPredefineTest");
            }
        }

        public ObservableCollection<Test> PredefinedTests { get; set; }

        public Test SelectedPredefinedTest
        {
            get { return _selectedPredefineTest; }
            set
            {
                _selectedPredefineTest = value;
                OnPropertyChanged("SelectedPredefinedTest");
            }
        }

        MainForm Control { get; set; }

        public bool CanRunTests
        {
            get
            {
                return Tests.Any();
            }
        }

        #endregion
        
        #region ctor

        public MainWindowViewModel(MainForm control)
        {
            Control = control;
            ExportToExcel = false;
            ShowChart = true;
            Tests = new ObservableCollection<Test>();
            PredefinedTests = new ObservableCollection<Test>();
            InitPredefiniedTests();
        }

        #endregion

        #region Public Methods

        public void LoadPredefinedTests()
        {
            Tests.Add(SelectedPredefinedTest.Copy());
            OnPropertyChanged("CanRunTests");
        }

        public void AddNewTest()
        {
            Tests.Add(new Test());
            OnPropertyChanged("CanRunTests");
        }

        internal void DeleteTests()
        {
            if (SelectedTests != null && SelectedTests.Any())
            {
                foreach (var test in SelectedTests)
                {
                    Tests.Remove(test);
                }
                OnPropertyChanged("CanRunTests");
            }
        }

        public void RunTests()
        {
            var message = "";
            foreach (var test in Tests)
            {
                if (!test.ValidateUri())
                {
                    message += string.Format("{0} - Nieprawidłowy URL\n",test.TestName);
                }
                if (!test.ValidateParameters())
                {
                    message += string.Format("{0} - Nieprawidłowy parametry\n",test.TestName);
                }
            }
            if (Tests.GroupBy(t => t.TestName).Any(g => g.Count() > 1))
            {
                message += "Nazwy testów muszą być unikalne";
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message,"Błąd",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Control.ReadOnly = true;
            Control.UseWaitCursor = true;

            DataSet ds = new DataSet("New_DataSet");
            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    foreach (var test in Tests)
                    {
                        test.RequestCompleted += new Test.ProgresChangedEventHandler((title, iteration, max) =>
                        {
                            Control.BeginInvoke(new Action(() =>
                            {
                                Control.UpdateProgress(title + "\n" + iteration + @"\" + max);
                            }));
                        });
                        ds.Tables.Add(test.RunTest());
                    }

                    if (ExportToExcel)
                    {
                        SaveToExcel(ds);
                    }

                    if (ShowChart)
                    {
                        Control.BeginInvoke(new Action(() =>
                        {
                            var chart = new LineChart(ds);
                        }));
                    }

                    Control.BeginInvoke(new Action(() =>
                    {
                        Control.ReadOnly = false;
                        Control.UseWaitCursor = false;
                        Control.HideProgressBar();
                    }));
                }
            ));
            backgroundThread.Start();
        }

        public void OpenParametersWindow(Test test)
        {
            var parametersDetails = new ParametersDetails(test.Parameters);
            Control.ReadOnly = true;
            parametersDetails.FormClosed += new FormClosedEventHandler((obj, args) =>
            {
                Control.ReadOnly = false;
                test.Parameters = parametersDetails.Parameters.ToDictionary(par => par.Name, par => par.Value, StringComparer.OrdinalIgnoreCase);
                Control.RefresGrid();
            });
            parametersDetails.Show();
        }

        #endregion

        #region Private Methods

        private void InitPredefiniedTests()
        {
            Test WikipediaTest = new Test("Zapytania do Wikipedia", "https://en.wikipedia.org/w/api.php");
            WikipediaTest.Parameters.Add("action", "query");
            WikipediaTest.Parameters.Add("titles", "Poland");
            WikipediaTest.Parameters.Add("prop", "revisions");
            WikipediaTest.Parameters.Add("rvprop", "content");
            WikipediaTest.Parameters.Add("format", "json");
            PredefinedTests.Add(WikipediaTest);

            Test GuardianTest = new Test("Zapytania do Guardian", "http://content.guardianapis.com/tags");
            GuardianTest.Parameters.Add("page-size", "500");
            GuardianTest.Parameters.Add("q", "football");
            GuardianTest.Parameters.Add("api-key", "test");
            PredefinedTests.Add(GuardianTest);

            Test omdb = new Test("Zapytenie do OpenMovieDataBase", "http://www.omdbapi.com/");
            omdb.Parameters.Add("t", "beautiful + mind");
            omdb.Parameters.Add("plot", "full");
            PredefinedTests.Add(omdb);

            Test UniversitiesUSA = new Test("Uczenlnie w USA", "http://universities.hipolabs.com/search");
            UniversitiesUSA.Parameters.Add("country", "United%20States");
            PredefinedTests.Add(UniversitiesUSA);

            Test PostServer = new Test("postserver.com", "http://posttestserver.com/post.php");
            PostServer.Method = "POST";
            PostServer.RunXTimes = 3;
            PostServer.Parameters.Add("Value1", "Hello");
            PostServer.Parameters.Add("Value2", "World");
            PredefinedTests.Add(PostServer);
        }

        private void ExportToXml(List<double> list)
        {
            DataSet ds = new DataSet("New_DataSet");
            DataTable dt = new DataTable(ConstantNames.times);
            
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            dt.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

            dt.Columns.Add(ConstantNames.times, typeof(double));
            foreach (var time in list)
            {
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = time;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);
            SaveToExcel(ds);
        }

        private void SaveToExcel(DataSet ds)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel File (*.xls)|*.xls|Excel File (*.xlsx*)|*.xlsx*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               ExcelLibrary.DataSetHelper.CreateWorkbook(saveFileDialog.FileName, ds);
            }
        }

        #endregion
    }
}
