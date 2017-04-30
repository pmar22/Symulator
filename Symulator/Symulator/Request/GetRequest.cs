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
    public class GetRequest : BaseRequest, IRequest
    {
        public GetRequest(String url) : base(url)
        {
            _requestMethod = ConstantNames.get;
        }

        protected override void MakeRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(FullUrl);
            request.Method = _requestMethod;
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }


        }
    }
}
