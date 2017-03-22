using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    interface RequestInterface
    {
        void Execute();
        void SetParameters(String name, String value);
        double GetTimeExecution();

    }
}
