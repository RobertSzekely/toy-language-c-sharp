namespace domain.Expression
{
    using System;
    using Test.domain.DataType;
    using MyIDictionary = domain.DataTypes.MyIDictionary;

    [Serializable()]
    public class VarExp : Exp
    {

        internal string mId;

        public VarExp(string id)
        {
            mId = id;
        }

        //Evaluates the exp
        public override int Eval(MyIDictionary tbl, MyIHeap heap)
        {
            return tbl.Lookup(mId);
        }

        //converts the exp to string
        public override string ToString()
        {
            return mId;
        }

        public string GetId()
        {
            return mId;
        }
    }

}