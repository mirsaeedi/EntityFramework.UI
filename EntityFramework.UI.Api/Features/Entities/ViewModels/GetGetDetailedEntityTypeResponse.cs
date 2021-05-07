using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Entities
{
	internal class GetGetDetailedEntityTypeResponse
	{
		public GetGetDetailedEntityTypeResponse(DetailedEntityType detailedEntityType)
		{
			EntityType = detailedEntityType;
		}

		public DetailedEntityType EntityType { get; set; }
	}
}
