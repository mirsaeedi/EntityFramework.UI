using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.UI;
using Microsoft.EntityFrameworkCore;

namespace EntityFranework.UI.Metadata.Infrastructure
{
	public class DbContextUIRegistrar : IDbContextUIRegistrar
	{
		private readonly Dictionary<string, (Type DbContextUI, Type DbContext)> _dbContexts
			= new Dictionary<string, (Type DbContextUI, Type DbContext)>();

		public void Register<TDBContextUI, TDbContext>(string name)
			where TDBContextUI : DbContextUI<TDbContext>
			where TDbContext : DbContext
		{

			if (_dbContexts.ContainsKey(name))
			{
				// TODO:
			}

			_dbContexts.Add(name, (typeof(TDBContextUI), typeof(TDbContext)));
		}

		public IReadOnlyCollection<(Type DbContextUI, Type DbContext)> Get()
			=> _dbContexts.Values.ToList().AsReadOnly();

		public (Type DbContextUI, Type DbContext) Get(string name)
			=> _dbContexts.GetValueOrDefault(name);
	}
}
