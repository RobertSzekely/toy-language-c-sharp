using domain.DataTypes;
using domain.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.domain.DataType;
using WindowsFormsApplication2;

namespace Test.domain.Expressions
{
    [Serializable()]
    class ReadExp : Exp
    {
        
        private string readNumberAsString;

        public ReadExp()
        {
            
        }

     
    public override int Eval(MyIDictionary tbl, MyIHeap heap) 
        {
            GetIntInput inp = new GetIntInput();
            inp.ShowDialog();


            return Int32.Parse(inp.GetText());

        }

        
    public override string ToString()
        {
            return readNumberAsString;
        }
    }
}
