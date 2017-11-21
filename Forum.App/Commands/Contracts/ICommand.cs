namespace Forum.App.Commands.Contracts
{
    public interface ICommand
    {
	    string Execute(params string[] arguments);
    }
}
