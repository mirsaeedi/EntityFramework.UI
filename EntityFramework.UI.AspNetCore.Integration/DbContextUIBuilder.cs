using EntityFramework.UI.Metadata;
using EntityFrameworkCore.UI.Infrastructure;
using EntityFranework.UI.Metadata.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EntityFramework.UI.AspNetCore.Integration
{
	public class DbContextUIBuilder
	{
		private readonly IServiceCollection _serviceCollection;
		private readonly IDbContextUIRegistrar _dbContextUIRegistrar;

		internal DbContextUIBuilder(IServiceCollection serviceCollection, IDbContextUIRegistrar dbContextUIRegistrar)
		{
			_serviceCollection = serviceCollection;
			_dbContextUIRegistrar = dbContextUIRegistrar;
		}

		public DbContextUIBuilder For<TDbContextUI, TDbContext>(string name = null)
			where TDbContextUI : DbContextUI<TDbContext>
			where TDbContext : DbContext
		{
			if (name == null)
			{
				name = typeof(TDbContextUI).Name;
			}

			_dbContextUIRegistrar.Register<TDbContextUI, TDbContext>(name);

			_serviceCollection.AddSingleton<TDbContextUI>();
			_serviceCollection.AddSingleton<IModelCustomizer<TDbContext>>(new ModelCustomizer<TDbContext>());
			_serviceCollection.AddSingleton(sp => GetModelSource<TDbContext>(sp));

			return this;
		}

		private static IModelSource<TDbContext> GetModelSource<TDbContext>(IServiceProvider sp) where TDbContext : DbContext
		{
			var modelCustomizer = sp.GetRequiredService<IModelCustomizer<TDbContext>>();
			var cache = new MemoryCache(new MemoryCacheOptions { SizeLimit = 10240 });
			var modelSource = new ModelSource<TDbContext>(modelCustomizer, cache);

			return modelSource;
		}
	}
}
