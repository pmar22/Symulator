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
        protected String _parameters;
        protected double _executionTime;
        protected string _requestMethod;

        #endregion

        #region Properties

        protected string FullUrl
        {
            get
            {
                if (_parameters.Length == 0)
                    return _mainUrl;
                else if (_mainUrl[_mainUrl.Length - 1] == '/')
                    return _mainUrl + "?" + _parameters;
                else
                    return _mainUrl + "/" + "?" + _parameters;
            }
        }

        public double ExecutionTime
        {
            get
            {
                return _executionTime;
            }
        }

        #endregion

        #region ctor

        internal BaseRequest(String url)
        {
            this._mainUrl = url;
            this._parameters = "";
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
        public void AddParameters(string name, string value)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
            {
                if (_parameters.Length == 0)
                    _parameters += name + "=" + value;
                else
                    _parameters += "&" + name + "=" + value;
            }
        }

        protected abstract void MakeRequest();

        #endregion
    }
}
