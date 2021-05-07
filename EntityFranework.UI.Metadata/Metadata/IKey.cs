using System.Collections.Generic;

namespace EntityFramework.UI.Metadata
{
	public interface IKey
	{
		IReadOnlyList<IProperty> Properties { get; }

		IEntityType DeclaringEntityType { get; }
	}
}