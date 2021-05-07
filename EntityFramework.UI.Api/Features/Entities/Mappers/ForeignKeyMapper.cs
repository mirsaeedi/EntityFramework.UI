using EntityFramework.UI.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.UI.Api.Features.Entities.Mappers
{
	public class ForeignKeyMapper
	{
		public ForeignKey Map(IForeignKey foreignKey)
		{
			return new ForeignKey
			{
				DeclaringEntityTypeName = foreignKey.DeclaringEntityType.Name,
				PrincipalEntityTypeName = foreignKey.PrincipalEntityType.Name,
				PrincipalKey = new KeyMapper().Map(foreignKey.PrincipalKey),
				Properties = new PropertyMapper()
					.Map(foreignKey.Properties)
					.ToList()
					.AsReadOnly(),
			};
		}

		public IEnumerable<ForeignKey> Map(IEnumerable<IForeignKey> foreignKeys)
		{
			foreach (var foreignKey in foreignKeys)
			{
				yield return Map(foreignKey);
			}
		}
	}
}
