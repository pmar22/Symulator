using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.PredefinedTests
{
    class UniversityPredefinedTest : BasePredefineTest
    {
        public UniversityPredefinedTest(string name) : base(name, "http://universities.hipolabs.com/search")
        {
        }
        public override DataSet RunTest(int RunXTimes)
        {
            DataSet ds = new DataSet("New_DataSet");

            DataTable dt = new DataTable("Uczelnie w Polsce");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {

                IRequest FirstRequest = new GetRequest("http://universities.hipolabs.com/search?country=poland");
                FirstRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = FirstRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Uczelnie w Stanach Zjednoczonych");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest SecondRequest = new GetRequest("http://universities.hipolabs.com/search?country=United%20States");
                SecondRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = SecondRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Politechnika Wrocławska");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest ThirdRequest = new GetRequest("http://universities.hipolabs.com/search?name=Technical%20University%20of%20Wroclaw");
                ThirdRequest.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = ThirdRequest.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            return ds;
        }

        protected override void MakeRequest()
        {
            throw new NotImplementedException();
        }
    }
}
