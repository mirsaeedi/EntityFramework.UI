using System;
using System.Reflection;

namespace EntityFramework.UI.Metadata.Internal
{
	public class Property : IProperty
	{
		public Property(Microsoft.EntityFrameworkCore.Metadata.IProperty property, EntityType entityType)
		{
			DeclaringEntityType = entityType;
			ClrType = property.ClrType;
			Name = property.Name;
			PropertyInfo = property.PropertyInfo;
			FieldInfo = property.FieldInfo;
		}

		public string Name { get; internal set; }

		public PropertyInfo? PropertyInfo { get; internal set; }

		public FieldInfo? FieldInfo { get; internal set; }

		public Type ClrType { get; internal set; }

		public EntityType DeclaringEntityType { get; internal set; }

		public string DisplayName { get; internal set; }

		public string DefaultValue { get; internal set; }

		public string PlaceHolder { get; internal set; }

		public bool IsReadOnly { get; internal set; }

		public bool IsIgnored { get; internal set; }

		public bool IsRequired { get; internal set; }

		public int? MaxLenght { get; internal set; }

		public int? MinLenght { get; internal set; }

		public bool Filterbale { get; internal set; }

		public bool IsIncludedInListColumns { get; internal set; }

		public int ListColumnIndex { get; internal set; }

		public string Tooltip { get; internal set; }
	}
}
