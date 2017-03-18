

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.TagHelpers {

    [HtmlTargetElementAttribute("dev-rock")]
    public class ImageTagHelper: TagHelper {

        [HtmlAttributeNameAttribute("name")]
        public string Name { set;get;}

        public ImageTagHelper() {

        }

        public override void Process(TagHelperContext context, TagHelperOutput output) {

            output.Attributes.SetAttribute("alt", "Hello, world!");
            output.Content.Append("Hello");

            base.Process(context, output);
        }
    }
}