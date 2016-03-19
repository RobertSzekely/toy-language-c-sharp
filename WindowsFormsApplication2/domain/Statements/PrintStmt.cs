namespace domain.Statement
{
    using System;
    using System.Runtime.Serialization;
    using DataTypes;
    using Exp = domain.Expression.Exp;

    [Serializable()]
    public class PrintStmt : IStmt
    {
        private Exp mExp;


        public PrintStmt(Exp exp)
        {
            mExp = exp;
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {

            state.AddOut(mExp.Eval(state.GetSymTable(), state.GetHeap()).ToString());

            return null;
        }
    



        //converts the statement to string
        public override string ToString()
        {
            return "print(" + mExp.ToString() + ")";
        }


    }

}