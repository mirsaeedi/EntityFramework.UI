using EntityFramework.UI;

namespace EntityFrameworkCore.UI.Infrastructure
{
	public class ModelCustomizer<TDbContext> : IModelCustomizer<TDbContext>
		where TDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public virtual void Customize(ModelBuilder<TDbContext> modelBuilder, DbContextUI<TDbContext> context)
		{
			context.OnModelCreating(modelBuilder);
		}
	}
}
