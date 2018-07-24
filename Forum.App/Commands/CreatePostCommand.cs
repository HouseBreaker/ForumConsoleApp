﻿using Forum.App.Commands.Contracts;
using Forum.App.Models;
using Forum.Services.Contracts;

namespace Forum.App.Commands
{
    public class CreatePostCommand : ICommand
    {
	    private readonly IPostService postService;
	    private readonly ICategoryService categoryService;
	    private readonly IUserSessionService userSessionService;

	    public CreatePostCommand(IPostService postService, ICategoryService categoryService, IUserSessionService userSessionService)
	    {
		    this.postService = postService;
		    this.categoryService = categoryService;
		    this.userSessionService = userSessionService;
	    }

	    public string Execute(params string[] arguments)
	    {
		    var categoryName = arguments[0];
		    var postTitle = arguments[1];
		    var postContent = arguments[2];

		    if (!userSessionService.IsLoggedIn())
		    {
			    return "You are not logged in!";
		    }

		    var category = categoryService.ByName<CategoryDto>(categoryName);

		    if (category == null)
		    {
			    category = categoryService.Create<CategoryDto>(categoryName);
		    }

		    var authorId = userSessionService.User.Id;
		    var categoryId = category.Id;

		    var post = postService.Create<PostDto>(postTitle, postContent, categoryId, authorId);

		    return $"Post with id {post.Id} created successfully!";
	    }
    }
}
