namespace EntityFramework.UI.Sample.Data
{
	public class BloggingContextUI : DbContextUI<BloggingContext>
	{
		protected override void OnModelCreating(ModelBuilder<BloggingContext> modelBuilder)
		{
			modelBuilder
				.HasDisplayName("First Db Context");

			modelBuilder
				.Entity<Blog>()
				.HasDisplayName("Blogs");

			modelBuilder
				.Entity<Blog>()
				.Property(x => x.BlogId)
						.HasDisplayName("Id of blog");

			modelBuilder
				.Entity<Post>()
				.HasDisplayName("Posts");
		}
	}

}