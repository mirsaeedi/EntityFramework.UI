using EntityFramework.UI.Metadata;
using System.Linq;

namespace EntityFramework.UI.Api.Features.Entities.Mappers
{
	public class EntityTypeMapper
	{
		public DetailedEntityType Map(IEntityType entityType)
		{
			return new DetailedEntityType
			{
				Name = entityType.Name,
				DisplayName = entityType.DisplayName,
				Properties = new PropertyMapper()
					.Map(entityType.Properties)
					.ToList()
					.AsReadOnly(),
				ForeignKeys = new ForeignKeyMapper()
					.Map(entityType.ForeignKeys)
					.ToList()
					.AsReadOnly(),
				PrimaryKey = new KeyMapper()
					.Map(entityType.PrimaryKey)
			};
		}
	}
}
