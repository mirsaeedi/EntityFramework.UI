using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace EntityFramework.UI.Metadata.Internal
{
	public class EntityType : IEntityType
	{
		private readonly HashSet<string> _ignoredMembers = new HashSet<string>();

		private Dictionary<string, Property> _properties;

		private List<ForeignKey> _foreignKeys;

		public EntityType(Microsoft.EntityFrameworkCore.Metadata.IEntityType entityType, Model model)
		{
			ClrType = entityType.ClrType;
			Model = model;
			Name = entityType.Name;

			SetProperties(entityType.GetProperties());
			SetPrimaryKey(entityType.FindPrimaryKey());
		}

		public virtual Type ClrType { get; }

		public virtual Model Model { get; }

		public virtual string Name { get; }

		public string DisplayName { get; internal set; }

		public virtual IKey? PrimaryKey { get; internal set; }

		public virtual IReadOnlyCollection<IProperty>? Properties
			=> _properties.Values;

		public virtual IReadOnlyCollection<IForeignKey>? ForeignKeys
			=> _foreignKeys.AsReadOnly();

		public virtual string AddIgnored([NotNull] string name)
		{
			_ignoredMembers.Add(name);

			return name;
		}

		public virtual IProperty? FindProperty([NotNull] string name)
			=> _properties.TryGetValue(name, out var property)
				? property
				: null;

		internal void AddForeignKeys(IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IForeignKey> foreignKeys)
		{
			_foreignKeys = new List<ForeignKey>();

			foreach (var foreignKey in foreignKeys)
			{
				_foreignKeys.Add(new ForeignKey(foreignKey, this));
			}
		}

		private void SetProperties(IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IProperty> properties)
		{
			_properties = new Dictionary<string, Property>();

			foreach (var property in properties)
			{
				_properties.Add(property.Name, new Property(property, this));
			}
		}

		private void SetPrimaryKey(Microsoft.EntityFrameworkCore.Metadata.IKey primaryKey)
		{
			PrimaryKey = new Key(primaryKey, this);
		}
	}
}
