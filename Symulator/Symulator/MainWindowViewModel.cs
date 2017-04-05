﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        MainForm Control { get; set; }

        #endregion

        #region ctor

        public MainWindowViewModel(MainForm control)
        {
            Control = control;
            Request = ConstantNames.get;
            LastExecutionTime = "0 s";
            RunXTimes = 1000;
        }

        #endregion

        #region Public Methods

        public void DoRequest()
        {
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
            DataTable dt = new DataTable("New_DataTable");
            
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            dt.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

            dt.Columns.Add(ConstantNames.times);
            foreach (var time in list)
            {
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = time;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            ExcelLibrary.DataSetHelper.CreateWorkbook("MyExcelFile.xls", ds);
        }

        #endregion
    }
}
