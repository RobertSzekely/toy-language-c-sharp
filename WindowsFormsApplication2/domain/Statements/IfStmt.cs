namespace domain.Statement
{
    using System;
    using System.Runtime.Serialization;
    using DataTypes;
    using Exp = domain.Expression.Exp;
    using Test.domain.Statements;

    [Serializable()]
    public class IfStmt : IStmt
    {

        public Exp mExp;
        public IStmt mThenS;
        public IStmt mElseS;

        public IfStmt(Exp exp, IStmt thenS, IStmt elseS)
        {
            mExp = exp;
            mThenS = thenS;
            mElseS = elseS;
        }


        public IfStmt(Exp exp, IStmt thenS)
        {
            mExp = exp;
            mThenS = thenS;
            mElseS = new SkipStmt();
        }
        public override string ToString()
        {
            return "IF(" + mExp.ToString() + ")THEN(" + mThenS.ToString() + ")ELSE(" + mElseS.ToString() + ")";

        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {
           
                if (mExp.Eval(state.GetSymTable(), state.GetHeap()) != 0)
                {
                   state.AddExeStack((T)mThenS);
                }
                else
                {
                    state.AddExeStack((T)mElseS);
                }
            return null;
        }
    }

}