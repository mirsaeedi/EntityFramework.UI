using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace EntityFrameworkUI.Model
{
    public class EntityInstance
    {
        public EntityField[] Fields { get; private set; }
        public IEntityType EntityType { get; private set; }
        public EntityField[] PrimaryKey { get; private set; }
        public EntityFieldSchema[] Schema => Fields.Select(q => q.Schema).ToArray();
        public EntityInstance(IEntityType entityType, EntityField[] fields, EntityField[] primaryKey)
        {
            Fields = fields;
            EntityType = entityType;
            PrimaryKey = primaryKey;
        }
    }
}
