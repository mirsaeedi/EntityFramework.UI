using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace EntityFramework.UI.Metadata.Internal
{
	public class Model : IModel
	{
		private readonly Dictionary<string, EntityType> _efEntityTypes
			= new Dictionary<string, EntityType>();

		private readonly Dictionary<string, EntityType> _uiEntityTypes
			= new Dictionary<string, EntityType>();

		private readonly Dictionary<Type, string> _clrTypeNameMap
			= new Dictionary<Type, string>();

		public virtual bool IsValidated { get; set; }

		public string Name { get; set; }

		public string DisplayName { get; set; }

		public Type DbContextClrType { get; set; }

		public virtual IReadOnlyCollection<IEntityType> GetEntityTypes()
			=> _uiEntityTypes.Values;

		public virtual IEntityType GetEntityType(string entityType)
			=> _uiEntityTypes.GetValueOrDefault(entityType, null);

		public virtual IEntityType FindEntityType(string name)
			=> _efEntityTypes.TryGetValue(name, out var entityType)
				? entityType
				: null;

		public virtual IEntityType FindEntityType(Type clrType)
			=> _clrTypeNameMap.TryGetValue(clrType, out var displayName)
				? FindEntityType(displayName)
				: null;

		internal virtual IEntityType AddEntityType([NotNull] Type type)
		{
			var entityType = FindEntityType(type);

			if (entityType == null)
			{
				// TODO:
			}

			if (_uiEntityTypes.ContainsKey(entityType.Name))
			{
				return entityType;
			}

			_uiEntityTypes.Add(entityType.Name, entityType as EntityType);

			return entityType;
		}

		internal virtual EntityType AddEntityType([NotNull] Microsoft.EntityFrameworkCore.Metadata.IEntityType entityType)
		{
			_efEntityTypes.Add(entityType.Name, new EntityType(entityType, this));
			_clrTypeNameMap.Add(entityType.ClrType, entityType.Name);

			return _efEntityTypes[entityType.Name];
		}

		internal virtual IModel FinalizeModel()
		{
			return MakeReadonly();
		}

		private IModel MakeReadonly()
		{
			IsValidated = true;
			return this;
		}
	}
}
