using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.DataType
{
    class MyIllegalArgumentException : DataTypesException
    {
        public MyIllegalArgumentException(string message) : base(message) { }
    
    }
}
