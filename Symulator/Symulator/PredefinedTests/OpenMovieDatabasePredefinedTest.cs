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
        public OpenMovieDatabasePredefinedTest(string name) : base(name)
        {
        }

        public override DataSet RunTest()
        {
            // TODO: Tutaj mają być wykonane requesty do http://www.omdbapi.com/, 
            // które przetestują różne zapytania różniące się wielkością zwracanych wyników oraz skomplikowaniem
            // wyniki mają być wpisane w zwracanego dataseta
            throw new NotImplementedException();
        }
    }
}
