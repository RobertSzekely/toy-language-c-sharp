using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.controller
{
    class ControllerException : Exception
    {
        public ControllerException(string message) : base(message) { }
    }
}
