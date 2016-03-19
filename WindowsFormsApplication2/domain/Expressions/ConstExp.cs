namespace domain.Expression
{
    using System;
    using Test.domain.DataType;
    using MyIDictionary = domain.DataTypes.MyIDictionary;

    [Serializable()]
    public class ConstExp : Exp
    {
        internal int mNumber;

        public ConstExp(int number)
        {
            mNumber = number;
        }

        // Evaluates the exp
        public override int Eval(MyIDictionary tbl, MyIHeap heap)
        {
            return mNumber;
        }

        //converts the exp to string
        public override string ToString()
        {
            return mNumber.ToString();
        }

    }

}