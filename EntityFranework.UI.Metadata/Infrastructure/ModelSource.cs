using EntityFramework.UI;
using EntityFramework.UI.Metadata;
using JetBrains.Annotations;
using Microsoft.Extensions.Caching.Memory;

namespace EntityFrameworkCore.UI.Infrastructure
{
	public class ModelSource<TDbContext> : IModelSource<TDbContext>
		where TDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		private readonly object _syncObject = new object();
		private readonly IMemoryCache _cache;
		private readonly IModelCustomizer<TDbContext> _modelCustomizer;

		public ModelSource(IModelCustomizer<TDbContext> modelCustomizer, IMemoryCache cache)
		{
			_cache = cache;
			_modelCustomizer = modelCustomizer;
		}

		public IModel GetModel(DbContextUI<TDbContext> dbContextUI, TDbContext dbContext)
		{
			var cacheKey = dbContextUI.GetType().ToString();

			if (!_cache.TryGetValue(cacheKey, out IModel model))
			{
				// Make sure OnModelCreating really only gets called once, since it may not be thread safe.
				lock (_syncObject)
				{
					if (!_cache.TryGetValue(cacheKey, out model))
					{
						model = CreateModel(dbContextUI, dbContext);
						model = _cache.Set(cacheKey, model, new MemoryCacheEntryOptions { Size = 100, Priority = CacheItemPriority.High });
					}
				}
			}

			return model;
		}

		protected virtual IModel CreateModel([NotNull] DbContextUI<TDbContext> dbContextUI, TDbContext dbContext)
		{
			var modelBuilder = new ModelBuilder<TDbContext>();

			modelBuilder.ApplyDbContext(dbContext);
			_modelCustomizer.Customize(modelBuilder, dbContextUI);

			return modelBuilder.FinalizeModel();
		}
	}
}
