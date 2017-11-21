using System;
using System.Linq;
using System.Text;
using Forum.App.Commands.Contracts;
using Forum.Services.Contracts;

namespace Forum.App.Commands
{
	public class ListPostsCommand : ICommand
	{
		private readonly IPostService postService;

		public ListPostsCommand(IPostService postService)
		{
			this.postService = postService;
		}

		public string Execute(params string[] arguments)
		{
			var posts = postService
				.All()
				.GroupBy(p => p.Category)
				.ToArray();

			var sb = new StringBuilder();

			foreach (var group in posts)
			{
				var categoryName = group.Key.Name;

				sb.AppendLine(categoryName + ":");

				foreach (var post in group)
				{
					sb.AppendLine($"  {post.Id}. {post.Title} - {post.Content} by {post.Author.Username}");
				}
			}

			return sb.ToString();
		}
	}
}
