using System;
using EntityFramework.UI.Metadata;
using EntityFrameworkCore.UI.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFranework.UI.Metadata.Infrastructure
{
	public class DbContextUIModelRegistry : IDbContextUIModelRegistry
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IDbContextUIRegistrar _dbContextUIRegistrar;

		public DbContextUIModelRegistry(IServiceProvider serviceProvider, IDbContextUIRegistrar dbContextUIRegistrar)
		{
			_serviceProvider = serviceProvider;
			_dbContextUIRegistrar = dbContextUIRegistrar;
		}

		public IModel GetModel(string name)
		{
			var (dbContextUIType, dbContextType) = _dbContextUIRegistrar.Get(name);

			Type modelSourceType = typeof(IModelSource<>).MakeGenericType(dbContextType);

			var modelSource = _serviceProvider.GetRequiredService(modelSourceType);

			var model = modelSourceType
				.GetMethod("GetModel")
				.Invoke(
					modelSource,
					new[] { _serviceProvider.GetRequiredService(dbContextUIType), _serviceProvider.GetRequiredService(dbContextType) }
				);

			return model as IModel;
		}
	}
}
