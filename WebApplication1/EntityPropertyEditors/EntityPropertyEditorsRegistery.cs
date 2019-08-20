using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkUI.EntityPropertyEditors
{
    public static class EntityPropertyEditorsRegistery
    {
        private static Dictionary<Type, EntityPropertyEditor> _clrTypeMappings = new Dictionary<Type, EntityPropertyEditor>();
        private static Dictionary<string, EntityPropertyEditor> _columnTypeMappings = new Dictionary<string, EntityPropertyEditor>();
        private static Dictionary<Type, EntityPropertyEditor> _modelPropertyMappings = new Dictionary<Type, EntityPropertyEditor>();
        public static void RegisterForClrType(Type clrType, EntityPropertyEditor entityPropertyEditor)
        {
            _clrTypeMappings[clrType] = entityPropertyEditor;
        }

        public static void RegisterForColumnType(string columnType, EntityPropertyEditor entityPropertyEditor)
        {
            _columnTypeMappings[columnType] = entityPropertyEditor;
        }

        public static void RegisterForModelProperty()
        {

        }

        public static EntityPropertyEditor ResolveEditorFor(IEntityType entity, IProperty property)
        {
            var entityPropertyEditor = GetEditorForModelProperty(entity,property);
            if (entityPropertyEditor != null)
                return entityPropertyEditor;

            entityPropertyEditor = GetEditorForColumnType(entity, property);
            if (entityPropertyEditor != null)
                return entityPropertyEditor;

            entityPropertyEditor = GetEditorForClrType(entity, property);
            if (entityPropertyEditor != null)
                return entityPropertyEditor;

            throw new Exception($"Nothing is registered for {property.ClrType} or {property.Relational().ColumnType}");
        }

        private static EntityPropertyEditor GetEditorForClrType(IEntityType entity, IProperty property)
        {
            var clrType = property.ClrType;
            if (_clrTypeMappings.ContainsKey(clrType))
                return _clrTypeMappings[clrType];

            return null;
                
        }

        private static EntityPropertyEditor GetEditorForColumnType(IEntityType entity, IProperty property)
        {
            var columnType = property.Relational().ColumnType;
            if (_columnTypeMappings.ContainsKey(columnType))
                return _columnTypeMappings[columnType];

            return null;
        }

        private static EntityPropertyEditor GetEditorForModelProperty(IEntityType entity, IProperty property)
        {
            return null;
        }
    }
}
