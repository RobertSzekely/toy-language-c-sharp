using domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.DataTypes;

namespace Test.domain.Statements
{
    class ForkStmt : IStmt
    {
        IStmt mStmt;

        public ForkStmt(IStmt stmt)
        {
            mStmt = stmt;
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {

            MyIStack<T> stk2 = new MyStack<T>();
            stk2.Push((T)mStmt);
            int id = state.GetId();
            MyDictionary sym2 = new MyDictionary();
            sym2 = (MyDictionary)state.GetSymTable().DeepCopy();
            PrgState<T> state2 = new PrgState<T>(
                stk2, sym2, state.GetOut(), state.GetHeap(), ++id);

            return state2;
        }

        public override string ToString()
        {
            return " forkStmt ( " + mStmt.ToString() + " ) ";
        }
    }
}
