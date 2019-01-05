namespace Infrastructure
{
    public interface ILevel
    {
        string AsString();
        bool CheckIfCorrect(string chosenOption);
    }
}