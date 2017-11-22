using Forum.App.Commands.Contracts;
using Forum.Services;
using Forum.Services.Contracts;

namespace Forum.App.Commands
{
    public class WhoAmICommand : ICommand
    {
	    private readonly IUserSessionService userSessionService;

	    public WhoAmICommand(IUserSessionService userSessionService)
	    {
		    this.userSessionService = userSessionService;
	    }

	    public string Execute(params string[] arguments)
	    {
		    if (!userSessionService.IsLoggedIn())
		    {
			    return "You are not logged in!";
		    }

		    var currentUser = userSessionService.User.Username;

		    return $"{currentUser}";
	    }
    }
}
