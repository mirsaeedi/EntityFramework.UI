using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkUI.EntityPropertyEditors
{
    
    public class NumericEntityPropertyEditor : FormGroupEntityPropertyEditor
    {
        public override async Task<string> RenderInput(IModelMetadataProvider modelMetadataProvider, TagHelperContext context, TagHelperOutput output, IEntityType entityType, IProperty property)
        {
            return ($@"<input type=""number"" class=""form-control"" id=""{Id}"" name=""{Name}"">");
        }
    }
}
