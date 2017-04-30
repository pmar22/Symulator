using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.PredefinedTests
{
    public abstract class BasePredefineTest : BaseRequest
    {
        public string TestName { get; set; }
        internal BasePredefineTest(string testName, String url) : base(url)
        {
            TestName = testName;
        }

        public abstract DataSet RunTest(int RunXTimes);
    }
}
