﻿using System.Text;
using Forum.App.Commands.Contracts;
using Forum.App.Models;
using Forum.Services.Contracts;

namespace Forum.App.Commands
{
    public class PostDetailsCommand : ICommand
    {
	    private readonly IPostService postService;

	    public PostDetailsCommand(IPostService postService)
	    {
		    this.postService = postService;
	    }

	    public string Execute(params string[] arguments)
	    {
		    var postId = int.Parse(arguments[0]);

		    var post = postService.ById<PostDetailsDto>(postId);

			//var postDto = new PostDetailsDto
			//{
			//	Id = post.Id,
			//	Title = post.Title,
			//	Content = post.Content,
			//	AuthorUsername = post.Author.Username,
			//	Replies = post.Replies.Select(r => new ReplyDto
			//	{
			//		Content = r.Content,
			//		AuthorUsername = r.Author.Username,
			//	})
			//};

			var sb = new StringBuilder();

		    sb.AppendLine($"{post.Title} by {post.AuthorUsername}");

		    foreach (var reply in post.Replies)
		    {
			    sb.AppendLine($"  - {reply.Content} by {reply.AuthorUsername}");
		    }

		    return sb.ToString();
	    }
    }
}
