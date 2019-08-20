using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkUI.Model
{
    public class EntityFieldSchema
    {
        public string Description { get; set; }
        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public Type ClrType { get; set; }
        public string ColumnType { get; set; }
        public bool IsKey { get; internal set; }
    }
}
