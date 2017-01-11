namespace Project.Contracts
{
    internal interface ICommand

    {
        string Execute(object obj);
    }
}