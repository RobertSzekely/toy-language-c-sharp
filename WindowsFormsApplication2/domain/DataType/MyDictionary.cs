using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Test.domain.DataType;

namespace domain.DataTypes
{
    [Serializable()]
    public class MyDictionary : MyIDictionary
    {

        //private int mSize;
        //private DictionaryItem[] dictionaryArray;

        private Dictionary<String, int> dictionaryArray;

        public MyDictionary()
        {

            dictionaryArray = new Dictionary<String, int>();
        }

        /// <summary>
        ///  find the variable with specific id
        /// </summary>
        public int Lookup(string id)
        {
            int value;
            try
            {
                dictionaryArray.TryGetValue(id, out value);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new MyNullPointerException("That Id cannot be found" + e.Message);
            }
            return value;
        }

        // updates the variable
        public void Update(string id, int val)
        {
            try
            {
                dictionaryArray.Remove(id);
                dictionaryArray.Add(id, val);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new MyNullPointerException("Error at Update in MyDictionary" + e.Message);
            }
            catch (ArgumentException ae)
            {
                throw new MyIllegalArgumentException("illegal argument" + ae.Message);
            }
        }

        //add a new variable to the dictionary
        public bool Add(string id, int val)
        {
            try
            {
                dictionaryArray.Add(id, val);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new MyNullPointerException("Error at Add method in MyDictionary" + e.Message);
            }
            catch (ArgumentException ae)
            {
                throw new MyIllegalArgumentException(ae.Message);
            }
            return true;
        }

        //converts to string
        public override string ToString()
        {
            string result = "\n Dictionary \n";
            int temp;
            List<string> keyList = new List<string>(this.dictionaryArray.Keys);
            foreach (string key in keyList)
            {
                dictionaryArray.TryGetValue(key, out temp);
                result += key + "=" + temp.ToString() + " , ";
            }
            return result;
        }

        public bool IsDefined(string id)
        {
            try
            {
                return dictionaryArray.ContainsKey(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new DataTypesException("Error at IsDefined in MyDictionary");
            }


        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }


        public object DeepCopy()
        {
            MyDictionary dic = new MyDictionary();
            foreach(KeyValuePair<String, int> entry in dictionaryArray)
            {
                dic.Add(entry.Key, entry.Value);
            }

            return dic;
        }

      
    }

}