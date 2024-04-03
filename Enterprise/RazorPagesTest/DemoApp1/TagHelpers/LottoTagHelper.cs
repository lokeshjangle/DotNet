using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DemoApp.TagHelpers;

[HtmlTargetElement("lotto", Attributes = "digit-count")]
public class LottoTagHelper : TagHelper
{
    public int DigitCount { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        var rdm = new Random();
        for(int i = 0; i < DigitCount; ++i)
        {
            var digit = rdm.Next(0, 10).ToString();
            output.Content.Append(digit);
        }
    }
}