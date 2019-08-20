using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkUI.EntityPropertyEditors
{
    
    public abstract class EntityPropertyEditor
    {
        public abstract Task RenderAsync(IModelMetadataProvider modelMetadataProvider, TagHelperContext context, TagHelperOutput output, IEntityType entityType, IProperty property);
    }

    public abstract class FormGroupEntityPropertyEditor: EntityPropertyEditor
    {
        public ModelMetadata PropertyMetadata { get; private set; }
        public string Name =>  PropertyMetadata.PropertyName;
        public string Id => PropertyMetadata.PropertyName;
        public string DisplayName => PropertyMetadata.DisplayName;
        public string Description => PropertyMetadata.Description;
        public override async Task RenderAsync(IModelMetadataProvider modelMetadataProvider, TagHelperContext context, TagHelperOutput output, IEntityType entityType, IProperty property)
        {
            var containerMetadata = modelMetadataProvider.GetMetadataForType(entityType.ClrType);
            PropertyMetadata = containerMetadata.Properties[property.Name];

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            output.Content
                .AppendHtml(await RenderLabel(modelMetadataProvider, context, output, entityType, property))
                .AppendHtml(await RenderInput(modelMetadataProvider, context, output, entityType, property))
                .AppendHtml(await RenderDescription(modelMetadataProvider, context, output, entityType, property))
                .AppendHtml(await RenderValidation(modelMetadataProvider, context, output, entityType, property));
        }

        public virtual async Task<string> RenderLabel(IModelMetadataProvider modelMetadataProvider, TagHelperContext context, TagHelperOutput output, IEntityType entityType, IProperty property)
        {
            return ($@"<label for=""{Name}"">{DisplayName}</label>");
        }

        public abstract Task<string> RenderInput(IModelMetadataProvider modelMetadataProvider, TagHelperContext context, TagHelperOutput output, IEntityType entityType, IProperty property);

        public virtual async Task<string> RenderDescription(IModelMetadataProvider modelMetadataProvider, TagHelperContext context, TagHelperOutput output, IEntityType entityType, IProperty property)
        {
            return ($@"<small class=""form-text text-muted"">{Description}</small>");
        }

        public virtual async Task<string> RenderValidation(IModelMetadataProvider modelMetadataProvider, TagHelperContext context, TagHelperOutput output, IEntityType entityType, IProperty property)
        {
            return "";
        }
        
    }
}
