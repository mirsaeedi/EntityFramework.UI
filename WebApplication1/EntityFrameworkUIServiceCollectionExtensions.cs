using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkUIServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContextUI<TContext>(this IServiceCollection serviceCollection) where TContext : DbContext
        {
            DbContextUIRegistrar.Register(typeof(TContext));
            return serviceCollection;
        }

    }
}
