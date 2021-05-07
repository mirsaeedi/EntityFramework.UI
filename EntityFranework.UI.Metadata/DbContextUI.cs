namespace EntityFramework.UI
{
	public abstract class DbContextUI<TDbContext>
		where TDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		protected internal abstract void OnModelCreating(ModelBuilder<TDbContext> modelBuilder);
	}
}
