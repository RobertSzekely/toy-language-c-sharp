using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.DataType
{
    class MyUnsupportedOperationException : DataTypesException
    {
        public MyUnsupportedOperationException(string message) : base(message) { }
    }
}
