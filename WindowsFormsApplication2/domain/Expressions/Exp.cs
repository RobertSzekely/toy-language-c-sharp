namespace domain.Expression
{
    using System;
    using System.Runtime.Serialization;
    using Test.domain.DataType;
    using MyIDictionary = domain.DataTypes.MyIDictionary;


    [Serializable()]
    public abstract class Exp 
    {

        //Evaluates the Exp
        public abstract int Eval(MyIDictionary tbl, MyIHeap heap);

        

        //converts exp to string
        public override abstract string ToString();
    }

}