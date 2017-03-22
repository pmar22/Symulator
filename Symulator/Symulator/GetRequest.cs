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
    class GetRequest : RequestInterface
    {
        String MainUrl;
        String Parameters;
        double ExecutionTime;

        public GetRequest(String Url) {
            this.MainUrl = Url;
            this.Parameters = "";
            ExecutionTime = 0;
        }
        public void Execute()
        {
            String fullURL = GetFullUrl();
            Console.WriteLine("FULL URL: " + fullURL);
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(fullURL);
                request.Method = "GET";
                String test = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())//WebException
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                    stopwatch.Stop();
                    ExecutionTime = (double)stopwatch.ElapsedMilliseconds / 1000;
                }
            }
            catch (WebException)
            {
                MessageBox.Show("Podaj prawidłowy adres URL", "Błąd adresu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExecutionTime = 0;
            }
            catch (UriFormatException) {
                MessageBox.Show("Podaj prawidłowy adres URL", "Błąd adresu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExecutionTime = 0;
            }
            Console.WriteLine(ExecutionTime);
            //Console.WriteLine(test);
        }

        public String GetFullUrl() {
            if (Parameters.Length == 0)
                return MainUrl;
            else if (MainUrl[MainUrl.Length - 1] == '/')
                return MainUrl + "?" + Parameters;
            else
                return MainUrl + "/" + "?" + Parameters;
        }

        public double GetTimeExecution()
        {
            return ExecutionTime;
        }

        public void SetParameters(string name, string value)
        {
            if (name != null && name.Length != 0 && value != null && value.Length != 0)
            {
                if (Parameters.Length == 0)
                    Parameters += name + "=" + value;
                else
                    Parameters += "&" + name + "=" + value;
            }
        }
    }
}
