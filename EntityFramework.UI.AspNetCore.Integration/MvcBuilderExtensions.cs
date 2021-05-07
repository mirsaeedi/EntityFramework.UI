using EntityFramework.UI.Api.Features.Entities;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EntityFramework.UI.AspNetCore.Integration
{
	public static class MvcBuilderExtensions
	{
		public static IMvcBuilder AddEntityFrameworkUI(this IMvcBuilder mvcBuilder)
		{
			mvcBuilder
				.ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(GetApiAssembly()));

			return mvcBuilder;
		}

		private static AssemblyPart GetApiAssembly()
		{
			var assembly = typeof(EntityTypesController).GetTypeInfo().Assembly;
			var part = new AssemblyPart(assembly);

			return part;
		}
	}
}