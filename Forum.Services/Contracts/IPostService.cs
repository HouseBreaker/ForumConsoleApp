using System;
using System.Linq;
using System.Linq.Expressions;
using Forum.Models;

namespace Forum.Services.Contracts
{
    public interface IPostService
    {
	    TModel Create<TModel>(string title, string content, int categoryId, int authorId);

	    IQueryable<TModel> All<TModel>();

		TModel ById<TModel>(int postId);

	    IQueryable<TModel> By<TModel>(Expression<Func<Post, bool>> predicate);
    }
}
