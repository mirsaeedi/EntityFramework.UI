namespace EntityFramework.UI
{
	public interface IEntityTypeUIConfiguration<TEntity>
		where TEntity : class
	{
		void Configure(EntityTypeBuilder<TEntity> builder);
	}
}
