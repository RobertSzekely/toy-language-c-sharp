using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.Expressions
{

    class MyDivisionByZeroException : ExpException
    {
        public MyDivisionByZeroException(string message) : base(message) { }
    }
}
