using domain.Expression;
using domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using domain.DataTypes;

namespace Test.domain.Statements
{
    [Serializable()]
    class IncStmt : IStmt
    {

        private string mVarName;

        public IncStmt(string varName)
        {
            mVarName = varName;
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {

            state.AddExeStack((T)(IStmt)new AssignStmt(mVarName, new ArithExp("+", new VarExp(mVarName), new ConstExp(1))));
            return null;

           
        }

        public String getVarName()
        {
            return mVarName;
        }

       

        public override string ToString()
        {
            return "INC(" + mVarName + ")";
        }
    }
}
