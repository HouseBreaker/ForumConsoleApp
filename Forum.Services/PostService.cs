using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Forum.Data;
using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.Services
{
    public class PostService : IPostService
    {
	    private readonly ForumDbContext context;

	    public PostService(ForumDbContext context)
	    {
		    this.context = context;
	    }

	    public Post Create(string title, string content, int categoryId, int authorId)
	    {
		    var post = new Post
		    {
			    Title = title,
			    Content = content,
			    CategoryId = categoryId,
			    AuthorId = authorId
		    };

		    context.Posts.Add(post);

		    context.SaveChanges();

		    return post;
	    }

	    public IEnumerable<TModel> All<TModel>()
	    {
		    var posts = context.Posts
				.ProjectTo<TModel>()
				.ToArray();

		    return posts;
	    }

	    public TModel ById<TModel>(int postId)
	    {
		    var post = context
			    .Posts
			    .Where(p => p.Id == postId)
			    .ProjectTo<TModel>()
				.First();

		    return post;
	    }
    }
}
