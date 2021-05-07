using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Entities
{
	public class ForeignKey
	{
		public IReadOnlyList<Property> Properties { get; set; }

		public Key PrincipalKey { get; set; }

		public string DeclaringEntityTypeName { get; set; }

		public string PrincipalEntityTypeName { get; set; }
	}
}