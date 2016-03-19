namespace domain.Statement
{
    using DataTypes;
    using System;
    using System.Runtime.Serialization;
    using Exp = domain.Expression.Exp;

    [Serializable()]
    public class AssignStmt : IStmt
    {

        private string mId;
        private Exp mExp;

        public AssignStmt(string id, Exp exp)
        {
            mId = id;
            mExp = exp;
        }
        //converts the statement to string
        public override string ToString()
        {
            return mId + "=" + mExp.ToString();
        }

        public string GetId()
        {
            
            {
                return mId;
            }
        }

        public Exp GetExp()
        {
            
            {
                return mExp;
            }
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {
            MyIDictionary symTbl = state.GetSymTable();
            int val;
          
            val = mExp.Eval(symTbl, state.GetHeap());

            if (symTbl.IsDefined(mId))
            {
                symTbl.Update(mId, val);
            }
            else
            {
                symTbl.Add(mId, val);
            }
            return null;
           
        }
    }

}