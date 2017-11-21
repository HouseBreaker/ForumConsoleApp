using Forum.Models;

namespace Forum.Services.Contracts
{
    public interface IUserService
    {
	    User ById(int id);

	    User ByUsername(string username);

	    User ByUsernameAndPassword(string username, string password);

	    User Create(string username, string password);

	    void Delete(int id);
    }
}
