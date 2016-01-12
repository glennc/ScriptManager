using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.TagHelpers;

namespace ScriptManagerTagHelper
{
    [HtmlTargetElement("segment", Attributes = "render")]
    
    public class SegmentRenderTag : TagHelper
    {
        private SegmentCollector _manager;

        public SegmentRenderTag(SegmentCollector manager)
        {
            _manager = manager;
        }

        public override int Order
        {
            get
            {
                return 3;
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //set TagName to null so that the placeholder tag doesn't render.
            output.TagName = null;

            var id = output.Attributes["render"];
            if (id == null)
            {
                throw new InvalidOperationException($"A segment must contain an attribute called render");
            }

            var contentToRender = _manager.GetContent(id.Value.ToString());

            if (contentToRender != null)
            {
                foreach (var scriptContent in _manager.Segments[id.Value.ToString()])
                {
                    var content = scriptContent.GetChildContentAsync().Result;
                    scriptContent.Content.SetContent(content);
                    output.Content.AppendHtml(scriptContent);
                }
            }
        }
    }
}
