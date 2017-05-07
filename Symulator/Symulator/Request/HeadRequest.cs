using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Request
{
    class HeadRequest : BaseRequest
    {
        public HeadRequest(String url) : base(url)
        {
            _requestMethod = ConstantNames.get;
        }
        protected override void MakeRequest()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_mainUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "HEAD";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
