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

        #region Fields

        private string _request;
        private string _url;
        private string _lastExecutionTime;
        private string _nameParameter;
        private string _valueParameter;
        private int _runXTimes;
        private BasePredefineTest _selectedPredefineTest;

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

        public ObservableCollection<BasePredefineTest> PredefinedTests { get; set; }

        public BasePredefineTest SelectedPredefineTest
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
            RunXTimes = 1000;

            PredefinedTests = new ObservableCollection<BasePredefineTest>();
            PredefinedTests.Add(new OpenMovieDatabasePredefinedTest("Zapytania do ombdapi.com"));

            SelectedPredefineTest = PredefinedTests[0];
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
            for (var i = 0; i < RunXTimes; ++i)
            {
                IRequest request = CreateProperRequestObject(Request, Url);
                request.AddParameters(NameParameter, ValueParameter);
                request.Execute();
                LastExecutionTime = request.ExecutionTime + " s";
                list.Add(request.ExecutionTime);
            }
            ExportToXml(list);
        }


        public void RunPredefinedTest()
        {
            if (SelectedPredefineTest != null)
            {
                SaveToExcel(SelectedPredefineTest.RunTest());
            }
        }

        #endregion

        #region Private Methods

        private IRequest CreateProperRequestObject(String requestType, String addressHTTP)
        {
            switch (requestType)
            {
                case "GET": return new GetRequest(addressHTTP);
                case "POST": return new PostRequest(addressHTTP);
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
