using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptManagerTagHelper
{
    [HtmlTargetElement(Attributes = "distinct")]
    public class DistinctRenderer : TagHelper
    {
        private DistinctTracker _tracker;

        public override int Order
        {
            get
            {
                return 1;
            }
        }

        public DistinctRenderer(DistinctTracker tracker)
        {
            _tracker = tracker;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var distinctAttribute = output.Attributes["distinct"];

            if(_tracker.DistinctTagsRendered.Contains(distinctAttribute.Value.ToString()))
            {
                output.SuppressOutput();
            }
            else
            {
                _tracker.DistinctTagsRendered.Add(distinctAttribute.Value.ToString());
                output.Attributes.Remove(distinctAttribute);
            }
        }

        private string GetUniqueId(TagHelperContext context, TagHelperOutput output)
        {
            var keyIdentifier = output.Attributes["distinct"].Value.ToString();
            return keyIdentifier;
        }
    }
}
