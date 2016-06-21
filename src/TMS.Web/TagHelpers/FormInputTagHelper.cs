using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace TMS.Web.TagHelpers
{
    [HtmlTargetElement("form-input", Attributes = ForAttributeName)]
    public class FormInputTagHelper : TagHelper
    {
        private const string ForAttributeName = "tms-value";
        
        private readonly IHtmlGenerator _generator;

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public FormInputTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            // Note null or empty For.Name is allowed because TemplateInfo.HtmlFieldPrefix may be sufficient.
            // IHtmlGenerator will enforce name requirements.
            var metadata = For.Metadata;
            var modelExplorer = For.ModelExplorer;
            if (metadata == null)
            {
                throw new InvalidOperationException($"Must be tag <input>, attribute name: {ForAttributeName},                    {nameof(IModelMetadataProvider)}, {For.Name})");
            }

            //< div class="form-group">
            //    <label asp-for="Value" class="col-md-2 control-label"></label>
            //    <div class="col-md-10">
            //        <input asp-for="Value" class="form-control" />
            //        <span asp-validation-for="Value" class="text-danger"></span>
            //    </div>
            //</div>

            

            var labelTag = _generator.GenerateLabel(ViewContext, modelExplorer, For.Name, For.Name, new { @class = "col-md-2 control-label" });

            output.Content.SetHtmlContent(labelTag);
        }
    }
}
