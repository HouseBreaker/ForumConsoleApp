namespace Forum.Models
{
	public class Reply
    {
	    public Reply()
	    {
	    }

	    public Reply(string content)
	    {
		    this.Content = content;
	    }

	    public Reply(string content, int authorId)
			: this(content)
	    {
		    this.AuthorId = authorId;
	    }

	    public Reply(string content, User author)
		    : this(content)
	    {
		    this.Author = author;
	    }

	    public int Id { get; set; }

		public string Content { get; set; }

		public int AuthorId { get; set; }

		public User Author { get; set; }

		public int PostId { get; set; }

	    public Post Post { get; set; }
    }
}
