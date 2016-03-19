namespace repository
{
    using domain.DataTypes;
    using System.Collections.Generic;
    using IStmt = domain.Statement.IStmt;

    public interface IRepository<T>
    {
        

        

        List<PrgState<T>> GetPrgList();

        void SetPrgList(List<PrgState<T>> prgList);

    }

}