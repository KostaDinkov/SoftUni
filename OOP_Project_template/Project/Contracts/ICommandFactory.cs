namespace Project.Contracts
{
    internal interface ICommandFactory
    {
        ICommand GetCommand(string input);
    }
}