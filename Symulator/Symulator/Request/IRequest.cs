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
        void AddParameters(String name, String value);
        double ExecutionTime { get; }
    }
}
