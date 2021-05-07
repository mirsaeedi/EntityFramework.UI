using EntityFramework.UI.Metadata;
using System;

namespace EntityFramework.UI.Api.Features.Data.Read
{
	public class ReadService
	{
		private readonly IModel _model;
		private readonly IServiceProvider _serviceProvider;

		public ReadService(IModel model, IServiceProvider serviceProvider)
		{
			_model = model;
			_serviceProvider = serviceProvider;
		}

		public void GetData(string entityType)
		{
		}

	}
}
