using System.Collections.Generic;

namespace EntityFramework.UI.Metadata.Internal
{
	public class Key : IKey
	{
		public Key(Microsoft.EntityFrameworkCore.Metadata.IKey key, IEntityType entityType)
		{
			var keyProperties = new List<IProperty>();

			foreach (var keyProperty in key.Properties)
			{
				keyProperties.Add(entityType.FindProperty(keyProperty.Name));
			}

			Properties = keyProperties;
		}

		public virtual IReadOnlyList<IProperty> Properties { get; }

		public virtual IEntityType DeclaringEntityType
		{
			get => Properties[0].DeclaringEntityType;
		}
	}
}
