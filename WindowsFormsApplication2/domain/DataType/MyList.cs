using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Test.domain.DataType;

namespace domain.DataTypes
{
    [Serializable()]
    public class MyList : MyIList
    {

        //private int mSize;
        //private string[] listArray;
        private List<string> output;


        public MyList()
        {
            output = new List<string>();
        }

       
        public bool Add(string element)
        {
            try
            {
                output.Add(element);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new DataTypesException("Error at Add in MyList");
            }
            return true;
        }

        

        public override string ToString()
        {
            string res = "\n Output \n";
            foreach (string str in output)
            {
                res += str + ",  ";
            }
            return res;
        }
    }

}