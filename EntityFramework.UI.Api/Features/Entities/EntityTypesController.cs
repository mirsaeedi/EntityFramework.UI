using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.UI.Api.Features.Entities
{
	[Route("api/efui/v1/schema")]
	public class EntityTypesController : ControllerBase
	{
		private EntityTypesService _entityTypesService;

		public EntityTypesController(EntityTypesService entityTypesService)
		{
			_entityTypesService = entityTypesService;
		}

		[HttpGet("entities")]
		public IActionResult GetEntityTypes()
		{
			var modelName = this.Request.Headers["model-name"];

			var entities = _entityTypesService.GetEntityTypes(modelName);
			var response = new GetEntityTypesResponse(entities);

			return Ok(response);
		}

		[HttpGet("entities/{entityName}")]
		public IActionResult GetDetailedEntityType(string entityName)
		{
			var modelName = this.Request.Headers["model-name"];

			var detailedEntityType = _entityTypesService.GetEntityType(modelName, entityName);
			var response = new GetGetDetailedEntityTypeResponse(detailedEntityType);

			return Ok(response);
		}

	}
}
