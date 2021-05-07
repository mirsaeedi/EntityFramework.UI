using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;

namespace EntityFramework.UI.AspNetCore.Integration
{
	public static class HostIntegrationExtensions
	{
		public static IApplicationBuilder UseEntityFrameworkUI(this IApplicationBuilder app, Func<HttpContext, bool> predicate)
		{
			return app.MapWhen(predicate, entityFrameworkUIMiddleware =>
			{
				entityFrameworkUIMiddleware.Use((ctx, nxt) =>
				{
					ctx.Request.Path = "/entityframeworkui" + ctx.Request.Path;
					return nxt();
				});

				entityFrameworkUIMiddleware.UseBlazorFrameworkFiles("/entityframeworkui");
				entityFrameworkUIMiddleware.UseStaticFiles();
				entityFrameworkUIMiddleware.UseStaticFiles("/entityframeworkui");
				entityFrameworkUIMiddleware.UseRouting();

				entityFrameworkUIMiddleware.UseEndpoints(endpoints =>
				{
					endpoints.MapControllers();
					endpoints.MapFallbackToFile("/entityframeworkui/{*path:nonfile}",
						  "entityframeworkui/index.html");
				});
			});
		}
	}
}
