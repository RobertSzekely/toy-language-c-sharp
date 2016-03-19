namespace domain.DataTypes
{

    public interface MyIDictionary
    {

        int Lookup(string id);

        void Update(string id, int val);

        bool Add(string id, int val);

        string ToString();

        bool IsDefined(string id);

        object DeepCopy();
    }

}