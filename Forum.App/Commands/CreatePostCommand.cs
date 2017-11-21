using System;
using Forum.App.Commands.Contracts;
using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.App.Commands
{
    public class CreatePostCommand : ICommand
    {
	    private readonly IPostService postService;
	    private readonly ICategoryService categoryService;

	    public CreatePostCommand(IPostService postService, ICategoryService categoryService)
	    {
		    this.postService = postService;
		    this.categoryService = categoryService;
	    }

	    public string Execute(params string[] arguments)
	    {
		    var categoryName = arguments[0];
		    var postTitle = arguments[1];
		    var postContent = arguments[2];

		    if (Session.User == null)
		    {
			    return "You are not logged in!";
		    }

		    var category = categoryService.ByName(categoryName);

		    if (category == null)
		    {
			    category = categoryService.Create(categoryName);
		    }

		    var authorId = Session.User.Id;
		    var categoryId = category.Id;

		    var post = postService.Create(postTitle, postContent, categoryId, authorId);

		    return $"Post with id {post.Id} created successfully!";
	    }
    }
}
