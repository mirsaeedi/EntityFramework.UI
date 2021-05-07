using System;
using System.Collections.Generic;
using EntityFramework.UI.Metadata.Internal;

namespace EntityFramework.UI.Metadata
{
	public interface IForeignKey
	{
		IReadOnlyList<IProperty> Properties { get; }

		IKey PrincipalKey { get; }

		IEntityType DeclaringEntityType { get; }

		IEntityType PrincipalEntityType { get; }
	}
}