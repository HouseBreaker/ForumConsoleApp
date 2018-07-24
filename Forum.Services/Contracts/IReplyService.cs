namespace Forum.Services.Contracts
{
	public interface IReplyService
	{
		TModel Create<TModel>(string replyText, int postId, int authorId);

		void Delete(int replyId);
	}
}
