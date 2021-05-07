using System;
using System.Collections.Generic;
using System.Reflection;
using EntityFramework.UI.Metadata.Internal;

namespace EntityFramework.UI.Metadata
{
	public interface IProperty
	{
		string Name { get; }

		PropertyInfo? PropertyInfo { get; }

		FieldInfo? FieldInfo { get; }

		Type ClrType { get; }

		EntityType DeclaringEntityType { get; }

		string DisplayName { get; }

		string DefaultValue { get; }

		string PlaceHolder { get; }

		bool IsReadOnly { get; }

		bool IsIgnored { get; }

		bool IsRequired { get; }

		int? MaxLenght { get; }

		int? MinLenght { get; }

		bool Filterbale { get; }

		bool IsIncludedInListColumns { get; }

		int ListColumnIndex { get; }

		string Tooltip { get; }
	}
}