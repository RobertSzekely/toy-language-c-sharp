using domain.DataTypes;
using domain.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.domain.DataType;

namespace Test.domain.Expressions
{
    [Serializable()]
    class BoolExp : Exp
    {

        private string mOp;
        private Exp mExp1;
        private Exp mExp2;

        public BoolExp(string op, Exp exp1, Exp exp2)
        {
            mOp = op;
            mExp1 = exp1;
            mExp2 = exp2;
        }

        public BoolExp(string op, Exp exp1)
        {
            mOp = op;
            mExp1 = exp1;
        }



        /**
         * Evaluates the expression
         * Return :
         * 	1 - true
         *  0 - false
         * @throws DataTypesException 
         */
        
    public override int Eval(MyIDictionary tbl, MyIHeap heap)
        {

        int rightOp = 0;
        int leftOp = mExp1.Eval(tbl, heap);
		if(mExp2 != null)
		{
		rightOp = mExp2.Eval(tbl, heap);
		}
		switch(mOp) 
		{
		case "==": 
			if (leftOp == rightOp) return 1;
			else return 0;
		case "!=": 
			if (leftOp != rightOp) return 1;
			else return 0;
		case "<": 
			if (leftOp<rightOp) return 1;
			else return 0;
		case "<=":
			if(leftOp <= rightOp) return 1;
			else return 0;
		case ">":
			if (leftOp > rightOp) return 1;
			else return 0;
		case ">=":
			if (leftOp >= rightOp) return 1;
			else return 0;
		case "&&": 
			if( leftOp != 0 && rightOp != 0) return 1;
			else return 0;
		case "||": 
			if (leftOp != 0 || rightOp != 0) return 1;
			else return 0;
		case "!":
			if(leftOp == 0) return 0;
			else return 1;
		default:
			return 0;
		}
	}

	
    public override string ToString()
{
    if (mExp2 != null)
        return mExp1.ToString() + " " + mOp + " " + mExp2.ToString();
    else return mOp.ToString() + "(" + mExp1.ToString() + ")";
}

    }
}
