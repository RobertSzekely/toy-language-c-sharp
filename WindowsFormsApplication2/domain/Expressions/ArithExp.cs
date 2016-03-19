namespace domain.Expression
{
    using System;
    using Test.domain.DataType;
    using Test.domain.Expressions;
    using MyIDictionary = domain.DataTypes.MyIDictionary;

    [Serializable()]
    public class ArithExp : Exp
    {
        internal Exp mExp1;
        internal Exp mExp2;
        internal string mOp;

        public ArithExp(string op, Exp exp1, Exp exp2)
        {
            mExp1 = exp1;
            mExp2 = exp2;
            mOp = op;
        }
        /// <summary>
        /// Evaluates the Expression
        /// </summary>
        public override int Eval(MyIDictionary tbl, MyIHeap heap)
        {
            int leftOp = mExp1.Eval(tbl, heap);
            int rightOp = mExp2.Eval(tbl, heap);
            switch (mOp)
            {
                case "+":
                    return leftOp + rightOp;
                case "-":
                    return leftOp - rightOp;
                case "*":
                    return leftOp * rightOp;
                case "/":
                    if (rightOp == 0)
                        throw new MyDivisionByZeroException("Division by zero");
                    else 
                        return leftOp / rightOp;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Converts the Exp to string
        /// </summary>
        public override string ToString()
        {
            return mExp1.ToString() + mOp + mExp2.ToString();
        }

    }

}