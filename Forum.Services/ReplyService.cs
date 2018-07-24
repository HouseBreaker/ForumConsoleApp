using System;
using AutoMapper;
using Forum.Data;
using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.Services
{
	public class ReplyService : IReplyService
	{
		private readonly ForumDbContext context;
		private readonly IMapper mapper;

		public ReplyService(ForumDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public TModel Create<TModel>(string replyText, int postId, int authorId)
		{
			var reply = new Reply
			{
				Content = replyText,
				PostId = postId,
				AuthorId = authorId
			};

			context.Replies.Add(reply);

			context.SaveChanges();

			var replyDto = mapper.Map<TModel>(reply);


			return replyDto;
		}

		public void Delete(int replyId)
		{
			throw new NotImplementedException();
		}
	}
}
