using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkUI.EntityPropertyEditors
{
    public static class EntityPropertyEditorsRegisteration
    {
        public static void Config()
        {
            
            var numericEntityPropertyEditor = new NumericEntityPropertyEditor();
            EntityPropertyEditorsRegistery.RegisterForClrType(typeof(int), numericEntityPropertyEditor);
            EntityPropertyEditorsRegistery.RegisterForClrType(typeof(long), numericEntityPropertyEditor);
            EntityPropertyEditorsRegistery.RegisterForClrType(typeof(double), numericEntityPropertyEditor);
            EntityPropertyEditorsRegistery.RegisterForClrType(typeof(float), numericEntityPropertyEditor);
            EntityPropertyEditorsRegistery.RegisterForClrType(typeof(decimal), numericEntityPropertyEditor);
            EntityPropertyEditorsRegistery.RegisterForClrType(typeof(byte), numericEntityPropertyEditor);
            EntityPropertyEditorsRegistery.RegisterForClrType(typeof(string), new StringEntityPropertyEditor());
        }
    }
}
