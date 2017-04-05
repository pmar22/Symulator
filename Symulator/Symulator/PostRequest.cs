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
    class PostRequest : RequestInterface
    {
        String MainUrl;
        String Parameters;
        double ExecutionTime;

        public PostRequest(String Url)
        {
            this.MainUrl = Url;
            this.Parameters = "";
            ExecutionTime = 0;
        }
        public void Execute()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(MainUrl);
                var postData = Parameters;
                var data = Encoding.ASCII.GetBytes(postData);
                request.Method = "POST";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                stopwatch.Stop();
                ExecutionTime = (double)stopwatch.ElapsedMilliseconds / 1000;
            }
            catch (WebException)
            {
                MessageBox.Show("Podaj prawidłowy adres URL", "Błąd adresu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExecutionTime = 0;
            }
            catch (UriFormatException)
            {
                MessageBox.Show("Podaj prawidłowy adres URL", "Błąd adresu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExecutionTime = 0;
            }
            Console.WriteLine(ExecutionTime);

        }


        public double GetTimeExecution()
        {
            return ExecutionTime;
        }

        public void SetParameters(string name, string value)
        {
            if (name != null && name.Length != 0 && value != null && value.Length != 0)
            {
                Parameters += name + "=" + value;
                //Console.WriteLine(Parameters);
            }
        }
    }
}