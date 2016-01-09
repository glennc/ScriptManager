using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptManagerTagHelper
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [HtmlTargetElement("script", Attributes = MARKER_ATTRIBUTE)]
    public class ScriptTag : TagHelper
    {
        private const string MARKER_ATTRIBUTE = "managed";
        private ScriptCollector _manager;

        public ScriptTag(ScriptCollector manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll(MARKER_ATTRIBUTE);
            var tagHelperOutput = new TagHelperOutput(output.TagName, output.Attributes, output.GetChildContentAsync);

            _manager.Scripts.Add(tagHelperOutput);
            output.SuppressOutput();
        }
    }

}
