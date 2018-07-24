namespace Forum.Services.Contracts
{
	public interface ICategoryService
	{
		TModel ByName<TModel>(string name);

		TModel Create<TModel>(string name);
	}
}
