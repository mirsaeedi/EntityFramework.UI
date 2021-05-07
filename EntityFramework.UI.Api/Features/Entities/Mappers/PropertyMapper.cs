using EntityFramework.UI.Metadata;
using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Entities.Mappers
{
	public class PropertyMapper
	{
		public Property Map(IProperty property)
		{
			return new Property
			{
				Name = property.Name,
				DisplayName = property.DisplayName,
				DefaultValue = property.DefaultValue,
				PlaceHolder = property.PlaceHolder,
				IsReadOnly = property.IsReadOnly,
				IsIgnored = property.IsIgnored,
				IsRequired = property.IsRequired,
				MaxLenght = property.MaxLenght,
				MinLenght = property.MinLenght,
				Filterbale = property.Filterbale,
				IsIncludedInListColumns = property.IsIncludedInListColumns,
				ListColumnIndex = property.ListColumnIndex,
			};
		}

		public IEnumerable<Property> Map(IEnumerable<IProperty> properties)
		{
			foreach (var property in properties)
			{
				yield return Map(property);
			}
		}
	}
}
