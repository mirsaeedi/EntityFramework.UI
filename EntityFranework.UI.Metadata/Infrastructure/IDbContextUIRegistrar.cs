using System;
using System.Collections.Generic;
using EntityFramework.UI;
using Microsoft.EntityFrameworkCore;

namespace EntityFranework.UI.Metadata.Infrastructure
{
	public interface IDbContextUIRegistrar
	{
		void Register<TDBContextUI, TDbContext>(string name)
			where TDBContextUI : DbContextUI<TDbContext>
			where TDbContext : DbContext;

		IReadOnlyCollection<(Type DbContextUI, Type DbContext)> Get();

		(Type DbContextUI, Type DbContext) Get(string name);
	}
}
