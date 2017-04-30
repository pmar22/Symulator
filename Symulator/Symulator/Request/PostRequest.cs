using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
namespace Symulator
{
    public class PostRequest : BaseRequest, IRequest
    {
        private String _postMethodData;
        public PostRequest(String url, String postData) : base (url)
        {
            _requestMethod = ConstantNames.post;
            _postMethodData = postData;
        }

        protected override void MakeRequest()
        {
             var request = (HttpWebRequest)WebRequest.Create(_mainUrl);
             var data = Encoding.ASCII.GetBytes(_postMethodData);
             request.Method = _requestMethod;
             request.ContentType = "application/x-www-form-urlencoded";
             request.ContentLength = data.Length;
             using (var stream = request.GetRequestStream())
             {
                 stream.Write(data, 0, data.Length);
             }
             var response = (HttpWebResponse)request.GetResponse();
             var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        }
    }
}