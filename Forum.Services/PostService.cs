using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Forum.Data;
using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.Services
{
    public class PostService : IPostService
    {
	    private readonly ForumDbContext context;
	    private readonly IMapper mapper;

	    public PostService(ForumDbContext context, IMapper mapper)
	    {
		    this.context = context;
		    this.mapper = mapper;
	    }

	    public TModel Create<TModel>(string title, string content, int categoryId, int authorId)
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

		    var postDto = mapper.Map<TModel>(post);

		    return postDto;
	    }

	    public IQueryable<TModel> By<TModel>(Expression<Func<Post, bool>> predicate)
	    {
		    var posts = context.Posts
				.Where(predicate)
			    .ProjectTo<TModel>(mapper.ConfigurationProvider);

		    return posts;
	    }

		public IQueryable<TModel> All<TModel>()
	    {
		    var posts = context.Posts
				.ProjectTo<TModel>(mapper.ConfigurationProvider);

		    return posts;
	    }

	    public TModel ById<TModel>(int postId)
	    {
		    var post = context
				.Posts
				.Where(p => p.Id == postId)
				.ProjectTo<TModel>(mapper.ConfigurationProvider)
				.SingleOrDefault();

		    return post;
	    }
    }
}
