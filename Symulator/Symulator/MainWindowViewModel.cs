using Charts;
using Symulator.PredefinedTests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symulator
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region Fields

        private string _request;
        private string _url;
        private string _lastExecutionTime;
        private string _nameParameter;// Do usunięcia
        private string _valueParameter;//Do usunięcia
        Dictionary<String, String> _requestsParameters;//Trzeba tutaj przechowywać aktualne parametry, czyli odpowiedni PredefinedTests.parameters(jest to robione w refreshDataFields i w konstruktorze), albo wczytywać z GUI z odpowiednich pól(trzeba zrobić)
        private int _runXTimes;
        private PredefinedTest _selectedPredefineTest;
        private bool _exportToExcel;
        private bool _showChart;
   
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

        public string Request
        {
            get { return _request; }
            set
            {
                _request = value;
                OnPropertyChanged("Request");
            }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("Url");
            }
        }

        public string LastExecutionTime
        {
            get { return _lastExecutionTime; }
            set
            {
                _lastExecutionTime = value;
                OnPropertyChanged("LastExecutionTime");
            }
        }

        public string NameParameter
        {
            get { return _nameParameter; }
            set
            {
                _nameParameter = value;
                OnPropertyChanged("NameParameter");
            }
        }

        public string ValueParameter
        {
            get { return _valueParameter; }
            set
            {
                _valueParameter = value;
                OnPropertyChanged("ValueParameter");
            }
        }

        public int RunXTimes
        {
            get { return _runXTimes; }
            set
            {
                _runXTimes = value;
                OnPropertyChanged("RunXTimes");
            }
        }

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

        public ObservableCollection<PredefinedTest> PredefinedTests { get; set; }

        public PredefinedTest SelectedPredefineTest
        {
            get { return _selectedPredefineTest; }
            set
            {
                _selectedPredefineTest = value;
                OnPropertyChanged("SelectedPredefineTest");
            }
        }

        MainForm Control { get; set; }

        #endregion


        #region ctor

        public MainWindowViewModel(MainForm control)
        {
            Control = control;
            Request = ConstantNames.get;
            LastExecutionTime = "0 s";
            RunXTimes = 100;
            ExportToExcel = false;
            ShowChart = true;
            PredefinedTests = new ObservableCollection<PredefinedTest>();
           // PredefinedTests = new ObservableCollection<BasePredefineTest>();
            initPredefiniedTests();
           // PredefinedTests.Add(new OpenMovieDatabasePredefinedTest("Zapytania do ombdapi.com"));
           // PredefinedTests.Add(new GuardianPredefinedTest("Zapytania do content.guardianapis.com"));
           // PredefinedTests.Add(new UniversityPredefinedTest("Zapytania do universities.hipolabs.com"));
            //PredefinedTests.Add(new WikipediaPredefinedTest("Zapytania do en.wikipedia.org"));
            SelectedPredefineTest = PredefinedTests[0];
            _requestsParameters = PredefinedTests[0].parameters;
        }

        #endregion

        #region Public Methods

        public void DoRequest()
        {
            if (!IsValidURI(Url))
            {
                MessageBox.Show("Podaj prawidłowy Url", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var list = new List<double>();
            String FullUrl = Url;
            if (Request.Equals("GET") || Request.Equals("HEAD")) {
                String parameters = prepareParameters();
                FullUrl = bindRequestUrlwithParameters(parameters);
            }
            IRequest request = CreateProperRequestObject(Request, FullUrl);
            for (var i = 0; i < RunXTimes; ++i)
            {
                request.Execute();
                LastExecutionTime = request.ExecutionTime + " s";
                list.Add(request.ExecutionTime);

            }

            if (ExportToExcel)
            {
                ExportToXml(list);
            }

            if (ShowChart)
            {
                var chart = new LineChart(list);
            }
        }
        public void refreshDataFields(int SelectedPredefinedTestIndex) {
            if (SelectedPredefinedTestIndex>=0) {
                _selectedPredefineTest = PredefinedTests[SelectedPredefinedTestIndex];
                foreach (KeyValuePair<string, string> entry in _selectedPredefineTest.parameters)
                {
                    NameParameter = entry.Key;//Do poprawy - zamiast dwóch zmiennych musi być jakaś kolekcja przechowująca wyświetlane nazwy i wartości dla GET i HEAD
                    ValueParameter = entry.Value;
                }
                Url = _selectedPredefineTest.BaseUrl;

            }
            _requestsParameters = _selectedPredefineTest.parameters;
        }


        private String bindRequestUrlwithParameters(String parameters)
        {
            String FullUrl;
            if (parameters.Length > 0)
                FullUrl = _url + "?" + parameters;
            else
                FullUrl = parameters;
            return FullUrl;
        }
        private String prepareParameters() {
            String result = "";
            int i = 0;
            foreach (String name in _requestsParameters.Keys)
            {
                String value = _requestsParameters[name];
                if (i == 0)
                    result += name + "=" + value;
                else
                    result += "&" + name + "=" + value;
                i++;
            }
            return result;
        }

       /* public void RunPredefinedTest()
        {
            if (SelectedPredefineTest != null)
            {
                var result = SelectedPredefineTest.RunTest(RunXTimes);
                if (ExportToExcel)
                {
                    SaveToExcel(result);
                }

                if (ShowChart)
                {
                    var chart = new LineChart(result);
                }
            }
        }*/

        #endregion

        #region Private Methods

        private void initPredefiniedTests()
        {
            PredefinedTest WikipediaTest = new PredefinedTest("Zapytania do Wikipedia", "http://en.wikipedia.org/w/api.php");
            WikipediaTest.parameters.Add("action", "query");
            WikipediaTest.parameters.Add("titles", "Poland");
            WikipediaTest.parameters.Add("prop", "revisions");
            WikipediaTest.parameters.Add("rvprop", "content");
            WikipediaTest.parameters.Add("format", "json");
            PredefinedTests.Add(WikipediaTest);
            PredefinedTest GuardianTest = new PredefinedTest("Zapytania do Guardian", "http://content.guardianapis.com/tags");
            GuardianTest.parameters.Add("page-size", "5");
            GuardianTest.parameters.Add("q", "football");
            GuardianTest.parameters.Add("api-key", "test");
            PredefinedTests.Add(GuardianTest);
        }


        private IRequest CreateProperRequestObject(String requestType, String addressHTTP)
        {
            switch (requestType)
            {
                case "GET": return new GetRequest(addressHTTP);
                case "POST": return new PostRequest(addressHTTP, prepareParameters());
                case "HEAD": throw new NotImplementedException();
                default: return null;
            }
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

        public static bool IsValidURI(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        #endregion
    }
}
