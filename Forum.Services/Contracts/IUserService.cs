using Forum.Models;

namespace Forum.Services.Contracts
{
    public interface IUserService
    {
	    TModel ById<TModel>(int id);

	    TModel ByUsername<TModel>(string username);

	    TModel ByUsernameAndPassword<TModel>(string username, string password);

	    User Create(string username, string password);

	    void Delete(int id);
    }
}
