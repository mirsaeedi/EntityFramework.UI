using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.UI.Sample.Data
{
	public class BloggingContext : DbContext
	{
		public BloggingContext(DbContextOptions<BloggingContext> options)
			: base(options)
		{ }

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }
	}

	public class Blog
	{
		[Display(Name = "Blog Id")]
		public int BlogId { get; set; }

		[Display(Name = "Url", Description = "Esi kalak")]
		public string Url { get; set; }

		public ICollection<Post> Posts { get; set; }
	}

	public class Post
	{
		public int PostId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public int BlogId { get; set; }
		public Blog Blog { get; set; }
	}

	public abstract class Contract
	{
		public int ContractId { get; set; }
		public DateTime StartDate { get; set; }
		public int Months { get; set; }
		public decimal Charge { get; set; }
	}
	public class MobileContract : Contract
	{
		public string MobileNumber { get; set; }
	}

	public class BroadbandContract : Contract
	{
		public int DownloadSpeed { get; set; }
	}
}