using EntityFramework.UI.Api.Features.Entities;
using EntityFranework.UI.Metadata.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFramework.UI.AspNetCore.Integration
{
	public static class ServiceCollectionExtensions
	{
		public static DbContextUIBuilder AddDbContextUI(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<EntityTypesService>();
			serviceCollection.AddScoped<DbContextUIModelRegistry>();
			serviceCollection.AddScoped<IDbContextUIModelRegistry>(sp => sp.GetRequiredService<DbContextUIModelRegistry>());

			var registrar = new DbContextUIRegistrar();
			serviceCollection.AddSingleton<IDbContextUIRegistrar>(registrar);

			var builder = new DbContextUIBuilder(serviceCollection, registrar);

			return builder;
		}
	}
}