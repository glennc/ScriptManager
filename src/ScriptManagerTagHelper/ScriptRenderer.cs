using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.TagHelpers;

namespace ScriptManagerTagHelper
{
    [HtmlTargetElement("render-managed-scripts")]
    public class ScriptRenderTag : TagHelper
    {
        private ScriptCollector _manager;

        public ScriptRenderTag(ScriptCollector manager)
        {
            _manager = manager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //set TagName to null so that the placeholder render-managed-scripts tag doesn't render.
            output.TagName = null;
            foreach (var scriptContent in _manager.Scripts)
            {
                var content = scriptContent.GetChildContentAsync().Result;
                scriptContent.Content.SetContent(content);
                output.Content.AppendHtml(scriptContent);
            }
        }
    }
}
