namespace EntityFramework.UI.Api.Features.Entities
{
	public class Property
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string DefaultValue { get; set; }

		public string PlaceHolder { get; set; }

		public bool IsReadOnly { get; set; }

		public bool IsIgnored { get; set; }

		public bool IsRequired { get; set; }

		public int? MaxLenght { get; set; }

		public int? MinLenght { get; set; }

		public bool Filterbale { get; set; }

		public bool IsIncludedInListColumns { get; set; }

		public int ListColumnIndex { get; set; }

		public string Tooltip { get; set; }
	}
}