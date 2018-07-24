namespace Forum.App.Models
{
	public class PostDto
	{
		public int Id { get; set; }

		public string CategoryName { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public string AuthorUsername { get; set; }
	}
}