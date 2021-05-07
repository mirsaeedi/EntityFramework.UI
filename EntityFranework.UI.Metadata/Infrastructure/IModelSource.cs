using EntityFramework.UI;
using EntityFramework.UI.Metadata;

namespace EntityFrameworkCore.UI.Infrastructure
{
	public interface IModelSource<TDbContext>
		where TDbContext : Microsoft.EntityFrameworkCore.DbContext
	{

		IModel GetModel(DbContextUI<TDbContext> context, TDbContext dbContext);
	}
}
