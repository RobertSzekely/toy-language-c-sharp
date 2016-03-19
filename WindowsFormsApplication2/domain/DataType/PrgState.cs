namespace domain.DataTypes
{
    using DataTypes;
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using Test.domain.DataType;
    using Test.domain.Expressions;
    using WindowsFormsApplication2;
    using IStmt = domain.Statement.IStmt;




    [Serializable()]
    public class PrgState<T> 
    {
        static object baton = new object();

        private MyIStack<T> exeStack;
        private MyIDictionary symTable;
        private MyIList @out;
        private MyIHeap mHeap;
        public T s;
        private int mId;

        public PrgState(MyIStack<T> stk, MyIDictionary symtbl, MyIList ot, MyIHeap heap, int id)
        {
            exeStack = stk;
            @out = ot;
            symTable = symtbl;
            mHeap = heap;
            mId = id;
        }

        public int GetId()
        {
            return mId;
        }
       
        public MyIStack<T> GetStk()
        {
            return exeStack;
        }   
        public void SetStk(MyIStack<T> value)
            {
                exeStack = value;
            }
        
        public MyIDictionary GetSymTable()
        {
                return symTable;
        }
        public void SetSymtable(MyIDictionary value)
          {
                symTable = value;
          }
        
        public  MyIList GetOut()
            {
                return @out;
            }

        public void SetOut(MyIList value)
            {
                @out = value;
            }
        
        public void AddExeStack(T st)
        {
            try
            {
                exeStack.Push(st);
            }
            catch (DataTypesException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new ExpException("Error at addExeStack in PrgState");
            }
        }
        public void AddSymTable(string id, int val)
        {
            try
            {
                symTable.Add(id, val);
            }
            catch (DataTypesException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new ExpException("Error at addSymTable");
            }

        }
        public void AddOut(string val)
        {
            try
            {
			@out.Add(val);
            }
            catch (DataTypesException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new ExpException("Error at addOut in PrgState");
            }
        }
        public T ExeStackPop()
        {
            T s;
            try
            {
                s = exeStack.Pop();
            }
            catch (DataTypesException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new ExpException("Error at exeStackPop");
            }
            return s;
        }

        public override string ToString()
        {
            return "\r\nStack Id: " + mId + "\r\n"+GetStk().ToString() + "\r\n"+
                    "\r\n------------------------------------------------"+ "\r\n" +
                    "\r\nDictionary Id: " + mId + "\r\n"+ GetSymTable().ToString() + "\r\n"+
                    "\r\n-------------------------------------------------\r\n" +
                    GetOut().ToString() +
                    "\r\n-------------------------------------------------\r\n" +
                    GetHeap().ToString() + "\r\n" +
                    "\r\n==================================================";
        }

        public MyIHeap GetHeap()
        {
            return mHeap;
        }

        public void SetHeap(MyIHeap heap)
        {
            mHeap = heap;
        }

        public  PrgState<T> OneStep()
        {
            lock(baton)
            {
                if (exeStack.IsEmpty()) return this;
                IStmt crtStmt = (IStmt)exeStack.Pop();
                return crtStmt.Execute(this);
            }
        }

        public void WriteToConsole(string @string)
        {
            Console.Write("{0}", @string);
        }

        public void WriteToText(string obj)
        {
            try
            {
                File.AppendAllText("fileee.txt", obj);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }

        public string DisplayState()
        {
            String result = "";
            result += "\nStack Id: " +mId+ GetStk().ToString() +
                    "------------------------------------------------" +
                     "\nDictionary Id: " +mId + GetSymTable().ToString() +
                    "\n-------------------------------------------------" +
                    GetOut().ToString() +
                    "\n-------------------------------------------------" +
                    GetHeap().ToString() + "\n" +
                    "\n==================================================";
            if(Form1.fileFlag)WriteToText(result);
            WriteToConsole(result);
            return result;
        }

        public bool IsNotCompleted()
        {
            return !exeStack.IsEmpty();
        }


    }//end of class

}//end of namespace