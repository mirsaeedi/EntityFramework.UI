using System;
using System.Collections.Generic;

namespace EntityFramework.UI.Metadata
{
	public interface IModel
	{
		public string DisplayName { get; set; }

		public Type DbContextClrType { get; set; }

		IEntityType FindEntityType(string name);

		IEntityType FindEntityType(Type clrType);

		IReadOnlyCollection<IEntityType> GetEntityTypes();

		IEntityType GetEntityType(string entityName);
	}
}