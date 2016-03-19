using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.DataType
{
    class MyClassCastException : DataTypesException
    {
        public MyClassCastException(string message) : base(message) { }
    }
}
