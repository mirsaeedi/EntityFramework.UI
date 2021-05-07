using EntityFramework.UI.Metadata;
using EntityFramework.UI.Metadata.Internal;
using JetBrains.Annotations;

namespace EntityFramework.UI
{
	public class ModelBuilder<TDbContext>
		where TDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		private Model _metadata;

		public ModelBuilder()
		{
			_metadata = new Model();
			_metadata.DbContextClrType = typeof(TDbContext);
		}

		public ModelBuilder<TDbContext> HasDisplayName(string displayName)
		{
			_metadata.DisplayName = displayName;

			return this;
		}

		public virtual EntityTypeBuilder<TEntity> Entity<TEntity>()
			where TEntity : class
		{
			var entityType = _metadata.AddEntityType(typeof(TEntity));

			return new EntityTypeBuilder<TEntity>(entityType as EntityType);
		}

		public virtual ModelBuilder<TDbContext> ApplyConfiguration<TEntity>([NotNull] IEntityTypeUIConfiguration<TEntity> configuration)
			where TEntity : class
		{
			configuration.Configure(Entity<TEntity>());

			return this;
		}

		internal virtual IModel FinalizeModel()
		{
			return _metadata.FinalizeModel();
		}

		internal virtual void ApplyDbContext(Microsoft.EntityFrameworkCore.DbContext dbContext)
		{
			var entityTypes = dbContext.Model.GetEntityTypes();

			foreach (var entityType in entityTypes)
			{
				_metadata.AddEntityType(entityType);
			}

			foreach (var entityType in entityTypes)
			{
				(_metadata.FindEntityType(entityType.Name) as EntityType).AddForeignKeys(entityType.GetForeignKeys());
			}
		}
	}
}
