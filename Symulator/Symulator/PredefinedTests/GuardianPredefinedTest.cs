using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.PredefinedTests
{
    public class GuardianPredefinedTest : BasePredefineTest
    {
        public GuardianPredefinedTest(string name) : base(name)
        {
        }

        public override DataSet RunTest(int RunXTimes)
        {
            DataSet ds = new DataSet("New_DataSet");

            DataTable dt = new DataTable("Football (5 items)");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {

                IRequest footballFirstRequest = new GetRequest("http://content.guardianapis.com/tags?page-size=5&q=football&api-key=test");
                footballFirstRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = footballFirstRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Football (1000 items)");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest footballSecondRequest = new GetRequest("http://content.guardianapis.com/tags?page-size=1000&q=football&api-key=test");
                footballSecondRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = footballSecondRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Football (500 items)");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest footballThirdRequest = new GetRequest("http://content.guardianapis.com/tags?page-size=500&q=football&api-key=test");
                footballThirdRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = footballThirdRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            return ds;
        }
    }
}
