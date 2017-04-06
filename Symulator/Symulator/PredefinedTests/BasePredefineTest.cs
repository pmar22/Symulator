using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.PredefinedTests
{
    public abstract class BasePredefineTest
    {
        public string TestName { get; set; }

        public BasePredefineTest(string testName)
        {
            TestName = testName;
        }

        public abstract DataSet RunTest();
    }
}
