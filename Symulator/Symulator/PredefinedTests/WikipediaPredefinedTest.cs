using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.PredefinedTests
{
    class WikipediaPredefinedTest : BasePredefineTest
    {
        public WikipediaPredefinedTest(string name) : base(name)
        {
        }

        public override DataSet RunTest(int RunXTimes)
        {
            DataSet ds = new DataSet("New_DataSet");

            DataTable dt = new DataTable("Wyszukiwanie: Polska");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {

                IRequest FirstRequest = new GetRequest("https://en.wikipedia.org/w/api.php?action=query&titles=Poland&prop=revisions&rvprop=content&format=json");
                FirstRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = FirstRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Wyszukiwanie: Strona główna");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest SecondRequest = new GetRequest("https://en.wikipedia.org/w/api.php?action=query&titles=Main%20Page&prop=revisions&rvprop=content&format=json");
                SecondRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = SecondRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            return ds;
        }
    }
}
