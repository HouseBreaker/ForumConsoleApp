using Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
	public class ForumDbContext : DbContext
	{
		public ForumDbContext()
		{
		}

		public ForumDbContext(DbContextOptions options)
			:base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Post> Posts { get; set; }

		public DbSet<Reply> Replies { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Category>()
				.HasMany(c => c.Posts)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId);

			builder.Entity<Reply>()
				.HasOne(r => r.Post)
				.WithMany(p => p.Replies)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<User>()
				.HasMany(u => u.Posts)
				.WithOne(p => p.Author)
				.HasForeignKey(p => p.AuthorId);

			builder.Entity<User>()
				.HasAlternateKey(u => u.Username);
		}
	}
}