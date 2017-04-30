using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.PredefinedTests
{
    public class OpenMovieDatabasePredefinedTest : BasePredefineTest
    {
        public OpenMovieDatabasePredefinedTest(string name) : base(name, "http://www.omdbapi.com")
        {
        }

        public override DataSet RunTest(int RunXTimes)
        {

            // TODO: Tutaj mają być wykonane requesty do http://www.omdbapi.com/, 
            // które przetestują różne zapytania różniące się wielkością zwracanych wyników oraz skomplikowaniem
            // wyniki mają być wpisane w zwracanego dataseta
            DataSet ds = new DataSet("New_DataSet");
        
            DataTable dt = new DataTable("Pianist");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++) {
                
                IRequest pianist = new GetRequest("http://www.omdbapi.com/?t=pianist");
                pianist.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = pianist.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Beautiful mind");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest beautifulMind = new GetRequest("http://www.omdbapi.com/?t=beautiful+mind&plot=full");
                beautifulMind.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = beautifulMind.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Moonlight");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest beautifulMind = new GetRequest("http://www.omdbapi.com/?i=tt4975722&plot=full");
                beautifulMind.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = beautifulMind.ExecutionTime;
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);

            dt = new DataTable("Movie not found");
            dt.Columns.Add(ConstantNames.times, typeof(double));
            for (int i = 0; i < RunXTimes; i++)
            {
                IRequest beautifulMind = new GetRequest("http://www.omdbapi.com/?t=abcdef");
                beautifulMind.Execute();
                var newRow = dt.NewRow();
                newRow[ConstantNames.times] = beautifulMind.ExecutionTime;
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
