using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.DataType
{
    class MyNullPointerException : DataTypesException
    {
        public MyNullPointerException(string message) : base(message) { }
    }
}
