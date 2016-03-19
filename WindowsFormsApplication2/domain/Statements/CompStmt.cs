using domain.DataTypes;
using System;
using System.Runtime.Serialization;

namespace domain.Statement
{
    [Serializable()]
    public class CompStmt : IStmt
    {

        public IStmt mFirst;
        public IStmt mSecond;

        public CompStmt(IStmt first, IStmt second)
        {
            mFirst = first;
            mSecond = second;
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {
            MyIStack<T> stk = state.GetStk();
            stk.Push((T)mSecond);
            
          
            stk.Push((T)mFirst);
            return null;
        }



        //converts the statement to string
        public override string ToString()
        {
            return "(" + mFirst.ToString() + ";" + mSecond.ToString() + ")";
        }
    }

}