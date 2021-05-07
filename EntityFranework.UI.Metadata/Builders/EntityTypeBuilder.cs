using System;
using System.Linq.Expressions;
using EntityFramework.UI.Internal;
using EntityFramework.UI.Metadata.Internal;

namespace EntityFramework.UI
{
	public class EntityTypeBuilder<TEntity>
		 where TEntity : class
	{
		private EntityType _metadata;

		public EntityTypeBuilder(EntityType metadata)
		{
			_metadata = metadata;
		}

		public virtual PropertyBuilder<TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
		{
			var memberInfo = propertyExpression.GetMemberAccess();
			var property = _metadata.FindProperty(memberInfo.GetSimpleMemberName());

			if (property == null)
			{
				// TODO:
			}

			return new PropertyBuilder<TProperty>(property as Property);
		}

		public EntityTypeBuilder<TEntity> HasDisplayName(string displayName)
		{
			_metadata.DisplayName = displayName;

			return this;
		}

		public virtual EntityTypeBuilder<TEntity> Ignore(Expression<Func<TEntity, object>> propertyExpression)
		{
			var memberInfo = propertyExpression.GetMemberAccess();
			var property = _metadata.FindProperty(memberInfo.GetSimpleMemberName());

			if (property == null)
			{
				// TODO:
			}

			_metadata.AddIgnored(property.Name);

			return this;
		}

		public virtual EntityTypeBuilder<TEntity> Orderby()
		{
			return this;
		}
	}
}
