using Forum.App.Commands.Contracts;

namespace Forum.App.Commands
{
    public class LogoutCommand : ICommand
    {
	    public string Execute(params string[] arguments)
	    {
		    if (Session.User == null)
		    {
			    return "You are not logged in!";
		    }

		    Session.User = null;

		    return "Logged out successfully!";
	    }
    }
}
