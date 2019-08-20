using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkUI.Model
{
    public class EntityField
    {

        public EntityField(EntityFieldSchema entityFieldSchema, string value)
        {
            Schema = entityFieldSchema;
            Value = value;
        }

        public string Value { get; set; }
        public EntityFieldSchema Schema { get; set; }
    }
}
