namespace domain.DataTypes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Test.domain.DataType;
    using IStmt = domain.Statement.IStmt;

    [Serializable()]
    public class MyStack<T> : MyIStack<T>
    {

        //private IStmt[] stackArray;
        //private int top;
        private Stack<T> stackArray;

        public MyStack()
        {
            stackArray = new Stack<T>();
        }
        public bool Push(T prg)
        {
                stackArray.Push(prg);
            return true;
        }
        public bool IsEmpty()
        {
                return stackArray.Count == 0;
        }

        public T Pop()
        {
            try
            {
                return stackArray.Pop();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new MyEmptyStackException("Error at pop in MyStack");
            }
        }
        public T Peek()
        {
            try
            {
                return stackArray.Peek();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new MyEmptyStackException("Error at peek in MyStack");
            }
        }

        public override string ToString()
        {
            String result = "\n Stack \n";

            foreach (T statement in stackArray)
            {
                if (statement != null)
                    result += statement.ToString() + "\n";
            }
            return result;
        }

        
    }

}