using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebNetSample.Core.Extensions;

[HtmlTargetElement("imagelink", Attributes = "webnetsample-id")]
public class ImageLinkTagHelper : TagHelper
{
    [HtmlAttributeName("webnetsample-id")]
    public string id { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Content.AppendHtml($@"<a href=""/Categories/GetImageById/id={id}"" alt=""Click to see image in a new tab""></a>");
        output.Attributes.Clear();
    }
}