using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.DataType
{
    class MyEmptyStackException : DataTypesException
    {
        public MyEmptyStackException(string message) : base(message) { }
    }
}
