using EntityFramework.UI;

namespace EntityFrameworkCore.UI.Infrastructure
{
	public interface IModelCustomizer<TDbContext>
		where TDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		void Customize(ModelBuilder<TDbContext> modelBuilder, DbContextUI<TDbContext> context);
	}
}
