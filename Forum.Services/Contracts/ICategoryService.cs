using Forum.Models;

namespace Forum.Services.Contracts
{
	public interface ICategoryService
	{
		TModel ByName<TModel>(string name);

		Category Create(string name);
	}
}
