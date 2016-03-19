using domain.DataTypes;
using System;
using System.Runtime.Serialization;
/// 
namespace domain.Statement
    
{

    /// <summary>
    /// @author sssse_000
    /// 
    /// </summary>

    
    public interface IStmt
    {
        
        string ToString();

     
        PrgState<T> Execute<T>(PrgState<T> state);
    }

  

}