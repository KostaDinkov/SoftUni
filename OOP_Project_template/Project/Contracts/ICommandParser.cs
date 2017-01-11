namespace Project.Contracts
{
    internal interface ICommandParser
    {
        string[] Parse(string input);
    }
}