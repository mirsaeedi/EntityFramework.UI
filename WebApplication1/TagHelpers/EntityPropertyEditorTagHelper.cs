
using EntityFrameworkUI.EntityPropertyEditors;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;

namespace EntityFrameworkUI.TagHelpers
{
    public class EntityPropertyEditorTagHelper:TagHelper
    {
        private IModelMetadataProvider _modelMetadataProvider;
        public EntityPropertyEditorTagHelper(IModelMetadataProvider modelMetadataProvider )
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public IEntityType EntityType { get; set; }
        public IProperty Property { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (Property.IsForeignKey())
                return;

            var editor = EntityPropertyEditorsRegistery.ResolveEditorFor(EntityType,Property);
            await editor.RenderAsync(_modelMetadataProvider, context, output, EntityType, Property);
        }
    }
}