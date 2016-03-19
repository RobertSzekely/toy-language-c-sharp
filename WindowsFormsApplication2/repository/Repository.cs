using System;

namespace repository
{
    using Test.domain.DataType;
    using Test.domain.Expressions;
    using domain.DataTypes;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;
    using System.IO;
    using System.Collections.Generic;

    public class Repository<T> : IRepository<T>
    {

        
        private List<PrgState<T>> mPrgStateList;

        public Repository(List<PrgState<T>> ps)
        {
            mPrgStateList = ps;
        }


        

        

        

        public List<PrgState<T>> GetPrgList()
        {
            return mPrgStateList;
        }

        public void SetPrgList(List<PrgState<T>> prgList)
        {
            mPrgStateList = prgList;
        }
    }// end of Repository Class

}//End of namespace