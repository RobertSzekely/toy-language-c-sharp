namespace domain.DataTypes
{

    using IStmt = domain.Statement.IStmt;

    public interface MyIStack<T>
    {

        bool Push(T prg);

        bool IsEmpty();

        T Pop();

        T Peek();

        

        string ToString();




    }

}