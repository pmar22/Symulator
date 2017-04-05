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
    public class PostRequest : BaseRequest, IRequest
    {
        public PostRequest(String url) : base (url)
        {
            _requestMethod = ConstantNames.post;
        }

        protected override void MakeRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(_mainUrl);
            var postData = _parameters;
            var data = Encoding.ASCII.GetBytes(postData);
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