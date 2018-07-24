using System.Collections.Generic;

namespace Forum.App.Models
{
	public class PostDetailsViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public int AuthorId { get; set; }

		public string AuthorUsername { get; set; }

		public ICollection<ReplyViewModel> Replies { get; set; }
	}

	public class ReplyViewModel
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public int AuthorId { get; set; }

		public string AuthorUsername { get; set; }
	}
}