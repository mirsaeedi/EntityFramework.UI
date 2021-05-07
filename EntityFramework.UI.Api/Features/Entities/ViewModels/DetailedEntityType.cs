using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Entities
{
	public class DetailedEntityType
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public Key? PrimaryKey { get; set; }

		public IReadOnlyCollection<Property> Properties { get; set; } = new List<Property>(0);

		public IReadOnlyCollection<ForeignKey> ForeignKeys { get; set; } = new List<ForeignKey>(0);
	}
}