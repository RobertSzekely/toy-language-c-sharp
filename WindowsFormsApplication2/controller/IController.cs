namespace controller
{
    using domain.DataTypes;
    using System.Collections.Generic;

    public interface IController<T>
    {

        

        void AllStep();

        List<PrgState<T>> SetStateList(T stmt);

        

        

        void DisplayAllStates();

    }

}