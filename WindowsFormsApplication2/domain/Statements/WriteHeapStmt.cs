using domain.Expression;
using domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.DataTypes;
using Test.domain.DataType;

namespace Test.domain.Statements
{
    [Serializable()]
    class WriteHeapStmt : IStmt
    {
        private String mVarName;
        private Exp mExp;

        public WriteHeapStmt(String varName, Exp exp)
        {
            mVarName = varName;
            mExp = exp;
        }

        public String GetVarName()
        {
            return mVarName;
        }

        public Exp GetExp()
        {
            return mExp;
        }

        public override string ToString()
        {
            return "WriteHeapStmt(" + mVarName + "," + mExp.ToString() + ")";
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {
            MyIHeap heap = state.GetHeap();
            MyIDictionary symTable = state.GetSymTable();
            if (symTable.IsDefined(mVarName))
            {
                heap.Update(symTable.Lookup(mVarName), mExp.Eval(symTable, heap)); ;
            }
            else
            {
                throw new ArgumentException("Heap address undefined");
            }

            return null;
        }
    }
}
