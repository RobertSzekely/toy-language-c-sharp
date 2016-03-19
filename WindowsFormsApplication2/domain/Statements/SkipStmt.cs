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
    class SkipStmt : IStmt
    {
        public PrgState<T> Execute<T>(PrgState<T> state)
        {

            return null;



        }

        public override string ToString()
        {
            return "   (Skip)   ";
        }
    }
}
