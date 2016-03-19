using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.DataType
{
    public interface MyIHeap
    {
        int Get(int addr);

        void Put(int addr, int value);

        void Update(int addr, int value);

        int Size();

        bool ContainsKey(int addr);

        String ToString();
    }
}
