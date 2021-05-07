using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.UI.Metadata.Internal
{
	public class ForeignKey : IForeignKey
	{
		public ForeignKey(Microsoft.EntityFrameworkCore.Metadata.IForeignKey foreignKey, EntityType entityType)
		{
			DeclaringEntityType = entityType.Model.FindEntityType(foreignKey.DeclaringEntityType.Name);
			Properties = foreignKey.Properties.Select(p => DeclaringEntityType.FindProperty(p.Name)).ToList();

			PrincipalEntityType = entityType.Model.FindEntityType(foreignKey.PrincipalEntityType.Name);
			PrincipalKey = new Key(foreignKey.PrincipalKey, PrincipalEntityType);
		}

		public virtual IReadOnlyList<IProperty> Properties { get; }

		public virtual IKey PrincipalKey { get; }

		public virtual IEntityType DeclaringEntityType { get; }

		public virtual IEntityType PrincipalEntityType { get; }
	}
}
