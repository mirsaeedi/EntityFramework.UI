using EntityFramework.UI.Metadata.Internal;

namespace EntityFramework.UI
{
	public class PropertyBuilder<TProperty>
	{
		private Property _metadata;

		public PropertyBuilder(Property metadata)
		{
			_metadata = metadata;
		}

		public PropertyBuilder<TProperty> HasDisplayName(string displayName)
		{
			_metadata.DisplayName = displayName;

			return this;
		}

		public PropertyBuilder<TProperty> HasPlaceHolder(string placeHolder)
		{
			_metadata.PlaceHolder = placeHolder;

			return this;
		}

		public PropertyBuilder<TProperty> HasTooltip(string tooltip)
		{
			_metadata.Tooltip = tooltip;

			return this;
		}

		public PropertyBuilder<TProperty> IsReadonly(bool @readonly = true)
		{
			_metadata.IsReadOnly = @readonly;

			return this;
		}

		public virtual PropertyBuilder<TProperty> IsRequired(bool required = true)
		{
			_metadata.IsRequired = required;

			return this;
		}

		public PropertyBuilder<TProperty> HasMaxLength(int? maxLenght)
		{
			_metadata.MaxLenght = maxLenght;

			return this;
		}

		public PropertyBuilder<TProperty> HasMinLength(int? mixLenght)
		{
			_metadata.MinLenght = mixLenght;

			return this;
		}

		public PropertyBuilder<TProperty> IsFilterable(bool filterbale)
		{
			_metadata.Filterbale = filterbale;

			return this;
		}

		public PropertyBuilder<TProperty> IsIncludedInListColumns(bool includedInListColumns, int listColumnIndex = 0)
		{
			_metadata.IsIncludedInListColumns = includedInListColumns;
			_metadata.ListColumnIndex = listColumnIndex;

			return this;
		}
	}
}
