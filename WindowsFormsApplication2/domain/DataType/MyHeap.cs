using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.DataType
{
    [Serializable()]
    class MyHeap : MyIHeap

    {
        private Dictionary<int, int> heapMap;

        public MyHeap()
        {
            heapMap = new Dictionary<int, int>();
        }

        
        public int Get(int addr)
        {
            int value;
            heapMap.TryGetValue(addr, out value);
            return value;
        }

        public void Put(int addr, int value)
        {
            heapMap.Add(addr, value);
        }

        public void Update(int addr, int value)
        {
            heapMap.Remove(addr);
            heapMap.Add(addr, value);

        }

        public bool ContainsKey(int addr)
        {
            return heapMap.ContainsKey(addr);
        }

        public override string ToString()
        {
            String result = "\n Heap \n {  ";
            int temp;
            List<int> keyList = new List<int>(this.heapMap.Keys);

            foreach (int key in keyList)
            {
                heapMap.TryGetValue(key, out temp);
                result += key.ToString() + " -> " + temp.ToString() + ", ";
            }
            return result + "  }";
        }

        public int Size()
        {
            return heapMap.Count;
        }
    }
}
