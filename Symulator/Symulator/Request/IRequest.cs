using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    public interface IRequest
    {
        void Execute();
        double ExecutionTime { get; }

        Dictionary<string,string> Parameters { get; set; }
    }
}
