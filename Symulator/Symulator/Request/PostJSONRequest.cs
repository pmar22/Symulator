using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    public class PostJSONRequest : BaseRequest
    {
        public PostJSONRequest(String url, String parameterJSON) : base (url)
        {
            _dataJSON = parameterJSON;
            _requestMethod = ConstantNames.post;
        }
        protected override void MakeRequest()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_mainUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(_dataJSON);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
