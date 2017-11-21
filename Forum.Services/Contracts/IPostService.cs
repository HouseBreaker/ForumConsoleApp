using System.Collections.Generic;
using Forum.Models;

namespace Forum.Services.Contracts
{
    public interface IPostService
    {
	    Post Create(string title, string content, int categoryId, int authorId);

	    IEnumerable<Post> All();

		Post ById(int postId);
    }
}
