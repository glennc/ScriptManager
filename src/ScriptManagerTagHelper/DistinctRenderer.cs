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
            var uniqueId = GetUniqueId(context, output);
            if(_tracker.DistinctTagsRendered.Contains(uniqueId))
            {
                output.SuppressOutput();
            }
            else
            {
                _tracker.DistinctTagsRendered.Add(uniqueId);
            }
        }

        private string GetUniqueId(TagHelperContext context, TagHelperOutput output)
        {
            var keyIdentifier = output.Attributes["distinct"].Value.ToString();
            return keyIdentifier;
        }
    }
}
