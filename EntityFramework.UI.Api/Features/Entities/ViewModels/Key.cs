using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Entities
{
	public class Key
	{
		public IReadOnlyList<Property> Properties { get; set; }

		public string DeclaringEntityTypeName { get; set; }
	}
}