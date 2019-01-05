namespace Infrastructure
{
    public interface ILevel<T>
    {
        string AsString();
        bool CheckIfCorrect(T chosenOption);
    }
}