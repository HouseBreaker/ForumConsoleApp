using System.Collections.Generic;
using Forum.Models;

namespace Forum.Services.Contracts
{
    public interface IPostService
    {
	    Post Create(string title, string content, int categoryId, int authorId);

	    IEnumerable<TModel> All<TModel>();

		TModel ById<TModel>(int postId);
    }
}
