using domain.DataTypes;
using domain.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.domain.DataType;

namespace Test.domain.Expressions
{
    [Serializable()]
    class ReadHeapExp : Exp
    {
        private String mVarName;

        public ReadHeapExp(String varName)
        {
            mVarName = varName;
        }

        public override int Eval(MyIDictionary tbl, MyIHeap heap) 
	    {
            int heapAddr = tbl.Lookup(mVarName);
		
		    try
		    {
			    heap.ContainsKey(heapAddr);
		    }
		    catch(ArgumentNullException npe)
		    {
			    throw new MyNullPointerException("Heap memory location unallocated");
            }
		
		    return heap.Get(heapAddr);
	    }
	
	

        public override string ToString()
        {
            return "rH(" + mVarName + ")";
        }
    }
}
