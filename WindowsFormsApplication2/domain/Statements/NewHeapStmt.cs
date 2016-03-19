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
    class NewHeapStmt : IStmt
    {
        private String mVarName;
        private Exp mExp;

        public NewHeapStmt(String varName, Exp exp)
        {
            mVarName = varName;
            mExp = exp;
        }

        public override string ToString()
        {
            return "NewHeap( " + mVarName + " , " + mExp.ToString() + " )";
        }

        public String GetVarName()
        {
            return mVarName;
        }

        public Exp GetExp()
        {
            return mExp;
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {
            MyIHeap heap = state.GetHeap();
            MyIDictionary symTable = state.GetSymTable();
            if (symTable.IsDefined(mVarName))
            {
                symTable.Update(mVarName, heap.Size() + 1);
                heap.Put(heap.Size() + 1, mExp.Eval(symTable, heap));
            }
            else
            {
                

                symTable.Add(mVarName, heap.Size() + 1);
                heap.Put(heap.Size() + 1, mExp.Eval(symTable, heap));
            }

            return null;

        }
    }
}
