using EntityFramework.UI.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EntityFramework.UI.Api.Features.Data.Read
{
	[Route("api/efui/v1/data")]
	public class ReadController : ControllerBase
	{
		private ReadService _readService;

		public ReadController(ReadService readService)
		{
			_readService = readService;
		}

		[HttpGet("{entityName}")]
		public IActionResult GetData(string entityName)
		{
			return Ok();
		}
	}
}
