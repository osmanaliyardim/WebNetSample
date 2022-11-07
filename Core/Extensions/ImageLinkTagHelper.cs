using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebNetSample.Core.Extensions;

[HtmlTargetElement("imagelink", Attributes = "webnetsample-id")]
public class ImageLinkTagHelper : TagHelper
{
    [HtmlAttributeName("webnetsample-id")]
    public string id { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute("href", $"/Categories/GetImageById/id={id}");
        output.Attributes.SetAttribute("alt", "Click to see image in a new tab");
    }
}