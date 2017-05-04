using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    public class Test : INotifyPropertyChanged
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

        private static int testNumber = 1;

        #region Fields

        private Dictionary<string, string> _parameters;

        #endregion

        #region Properties

        public string TestName { get; set; }

        public int RunXTimes { get; set; }

        public string Method { get; set; }

        public string MainUrl { get; set; }

        public string ParametersString
        {
            get
            {
                return string.Join("&", Parameters.Select(x => x.Key + "=" + x.Value).ToArray());
            }
        }

        public Dictionary<string,string> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; OnPropertyChanged("ParametersString"); }
        }

        #endregion

        #region ctor

        public Test()
        {
            RunXTimes = 100;
            Method = "GET";
            TestName = "Test " + testNumber++;
            MainUrl = ConstantNames.textPrefix;
            _parameters = new Dictionary<string, string>();
        }

        public Test(string title, string mainUrl):this()
        {
            TestName = title;
            MainUrl = mainUrl;
        }

        #endregion

        #region Methods
        
        public bool ValidateUri()
        {
            if (!Uri.IsWellFormedUriString(MainUrl, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(MainUrl, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        public bool ValidateParameters()
        {
            return Parameters.All(kvp => !string.IsNullOrEmpty(kvp.Key) && !string.IsNullOrEmpty(kvp.Value));
        }

        public DataTable RunTest()
        {
            DataTable dt = new DataTable(TestName);
            dt.Columns.Add(ConstantNames.times, typeof(double));

            IRequest request = null;
            switch (Method)
            {
                case "GET":
                    request = new GetRequest(MainUrl);
                    break;
                case "POST":
                    request = new PostRequest(MainUrl);
                    break;
                case "HEAD":
                    throw new NotImplementedException();
            }

            request.Parameters = Parameters;

            for (int i = 0; i < RunXTimes; i++)
            {
                request.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = request.ExecutionTime;
                dt.Rows.Add(newRow);
                OnRequestCompleted(i+1);
            }
            return dt;
        }

        public Test Copy()
        {
            var copy = new Test();
            copy.RunXTimes = this.RunXTimes;
            copy.Method = this.Method;
            copy.TestName = this.TestName;
            copy.MainUrl = this.MainUrl;
            copy._parameters = this.Parameters;
            return copy;
        }

        #endregion

        protected virtual void OnRequestCompleted(int iteration)
        {
            ProgresChangedEventHandler handler = RequestCompleted;
            if (handler != null)
            {
                handler(TestName, iteration, RunXTimes);
            }
        }

        public event ProgresChangedEventHandler RequestCompleted;
        public delegate void ProgresChangedEventHandler(string name, int iteration, int max);
    }
}
