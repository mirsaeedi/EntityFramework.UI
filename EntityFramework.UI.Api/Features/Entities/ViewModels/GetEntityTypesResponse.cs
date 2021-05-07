using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Entities
{
	internal class GetEntityTypesResponse
	{
		public GetEntityTypesResponse(IReadOnlyCollection<EntityType> entityTypes)
		{
			EntityTypes = entityTypes;
		}

		public IReadOnlyCollection<EntityType> EntityTypes { get; set; }
	}
}
