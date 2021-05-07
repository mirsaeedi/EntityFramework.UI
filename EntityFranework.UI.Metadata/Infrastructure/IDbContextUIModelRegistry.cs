using EntityFramework.UI.Metadata;

namespace EntityFranework.UI.Metadata.Infrastructure
{
	public interface IDbContextUIModelRegistry
	{
		IModel GetModel(string name);
	}
}
