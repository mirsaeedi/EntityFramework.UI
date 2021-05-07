using System;
using System.Collections.Generic;
using EntityFramework.UI.Metadata.Internal;

namespace EntityFramework.UI.Metadata
{
	public interface IEntityType
	{
		Type ClrType { get; }

		Model Model { get; }

		string Name { get; }

		string DisplayName { get; }

		IKey? PrimaryKey { get; }

		IReadOnlyCollection<IProperty>? Properties { get; }

		IReadOnlyCollection<IForeignKey>? ForeignKeys { get; }

		IProperty FindProperty(string name);
	}
}