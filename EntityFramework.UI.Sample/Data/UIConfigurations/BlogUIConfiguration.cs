using EntityFramework.UI;

namespace EntityFramework.UI.Sample.Data.UIConfigurations
{
	public class BlogUIConfiguration : IEntityTypeUIConfiguration<Blog>
	{
		public void Configure(EntityTypeBuilder<Blog> builder)
		{
			builder.Ignore(x => x.BlogId);
		}
	}
}
