namespace Forum.Services.Contracts
{
    public interface IUserService
    {
	    TModel ById<TModel>(int id);

	    TModel ByUsername<TModel>(string username);

	    TModel ByUsernameAndPassword<TModel>(string username, string password);

	    TModel Create<TModel>(string username, string password);

	    void Delete(int id);
    }
}
