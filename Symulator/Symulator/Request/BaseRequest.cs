using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symulator
{
    public abstract class BaseRequest : IRequest
    {
        #region Fields

        protected String _mainUrl;
        protected double _executionTime;
        protected string _requestMethod;
        protected string _dataJSON;
        #endregion

        #region Properties

        protected string FullUrl
        {
            get
            {
                if (!Parameters.Any())
                    return _mainUrl;
                else
                    return _mainUrl + "?" + ParametersString;
            }
        }

        public string ParametersString
        {
            get
            {
                return string.Join("&", Parameters.Select(x => x.Key + "=" + x.Value).ToArray());
            }
        }

        public double ExecutionTime
        {
            get
            {
                return _executionTime;
            }
        }

        public Dictionary<string, string> Parameters { get; set; }

        #endregion

        #region ctor

        internal BaseRequest(String url)
        {
            this._mainUrl = url;
            this.Parameters = new Dictionary<string, string>();
            _executionTime = 0;
        }

        #endregion

        #region Methods

        public void Execute()
        {
            if (string.IsNullOrEmpty(_requestMethod))
            {
                throw new InvalidOperationException();
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                MakeRequest();
                stopwatch.Stop();
                _executionTime = (double)stopwatch.ElapsedMilliseconds / 1000;
            }
            catch (WebException)
            {
                MessageBox.Show("Podaj prawidłowy adres URL", "Błąd adresu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _executionTime = 0;
            }
            catch (UriFormatException)
            {
                MessageBox.Show("Podaj prawidłowy adres URL", "Błąd adresu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _executionTime = 0;
            }
        }

        protected abstract void MakeRequest();

        #endregion
    }
}
