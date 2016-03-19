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
    class WhileStmt : IStmt
    {
        private Exp mExp;
        private IStmt mStatement;

        public WhileStmt(Exp exp, IStmt statement)
        {
            mExp = exp;
            mStatement = statement;
        }

        
    public override String ToString()
        {
            return "WHILE(" + mExp.ToString() + ") {" + mStatement.ToString() + " }";
        }

        public Exp getExp()
        {
            return mExp;
        }

        public IStmt GetStatement()
        {
            return mStatement;
        }

        public PrgState<T> Execute<T>(PrgState<T> state)
        {
            
                if (mExp.Eval(state.GetSymTable(), state.GetHeap()) > 0)
                {

                    state.AddExeStack((T)(IStmt)this);
                    state.AddExeStack((T)mStatement);
                }
            return null;
        }
    }
}
