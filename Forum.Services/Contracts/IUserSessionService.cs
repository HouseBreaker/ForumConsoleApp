using Forum.Models;

namespace Forum.Services.Contracts
{
    public interface IUserSessionService
    {
	    User User { get; }

	    User Login(string username, string password);

	    void Logout();

	    bool IsLoggedIn();
    }
}
