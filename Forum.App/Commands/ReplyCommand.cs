using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Commands.Contracts;
using Forum.Services.Contracts;

namespace Forum.App.Commands
{
	public class ReplyCommand : ICommand
	{
		private readonly IReplyService replyService;
		private readonly IUserSessionService userSessionService;

		public ReplyCommand(IReplyService replyService, IUserSessionService userSessionService)
		{
			this.replyService = replyService;
			this.userSessionService = userSessionService;
		}

		public string Execute(params string[] arguments)
		{
			var postId = int.Parse(arguments[0]);
			var content = arguments[1];

			if (!userSessionService.IsLoggedIn())
			{
				return "You are not logged in!";
			}

			var authorId = userSessionService.User.Id;

			replyService.Create(content, postId, authorId);

			return "Reply created successfully";
		}
	}
}
