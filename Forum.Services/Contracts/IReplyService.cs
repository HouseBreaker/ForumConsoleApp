using Forum.Models;

namespace Forum.Services.Contracts
{
	public interface IReplyService
	{
		Reply Create(string replyText, int postId, int authorId);

		void Delete(int replyId);
	}
}
