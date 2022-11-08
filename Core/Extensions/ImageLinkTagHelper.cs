using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebNetSample.Core.Extensions;

[HtmlTargetElement("webnetsample-imagelink", TagStructure = TagStructure.NormalOrSelfClosing)]
public class ImageLinkTagHelper : TagHelper
{
    [HtmlAttributeName("image-id")]
    public string Id { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        
        output.Attributes.SetAttribute("href", $"/Categories/GetImageById/id={Id}");
    }
}