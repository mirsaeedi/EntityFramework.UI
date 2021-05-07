using EntityFramework.UI.Api.Features.Entities.Mappers;
using EntityFranework.UI.Metadata.Infrastructure;
using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Entities
{
	public class EntityTypesService
	{
		private IDbContextUIModelRegistry _dbContextUIModelRegistry;

		public EntityTypesService(IDbContextUIModelRegistry dbContextUIModelRegistry)
		{
			_dbContextUIModelRegistry = dbContextUIModelRegistry;
		}

		public IReadOnlyCollection<EntityType> GetEntityTypes(string modelName)
		{
			var model = _dbContextUIModelRegistry.GetModel(modelName);

			var result = new List<EntityType>();

			foreach (var entity in model.GetEntityTypes())
			{
				result.Add(new EntityType(entity.Name, entity.DisplayName));
			}

			return result;
		}

		public DetailedEntityType GetEntityType(string modelName, string entityTypeName)
		{
			var model = _dbContextUIModelRegistry.GetModel(modelName);

			var entityType = model.GetEntityType(entityTypeName);

			if (entityType == null)
			{
				// TODO: 
				return null;
			}

			var detailedEntityType = new EntityTypeMapper().Map(entityType);

			return detailedEntityType;
		}
	}
}
