using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.PredefinedTests
{
    public class PredefinedTest//Predefiniowane są tylko żądania metody get
    {
        public string TestName { get; set; }
        public String BaseUrl ;
        public Dictionary<String, String> parameters;
        public PredefinedTest(String TestName, String Url)
        {
            this.TestName = TestName;
            BaseUrl = Url;
            parameters = new Dictionary<string, string>();
        }
    }
}
