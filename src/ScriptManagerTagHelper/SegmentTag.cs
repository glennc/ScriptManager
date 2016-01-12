using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptManagerTagHelper
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [HtmlTargetElement(SEGMENT_TAG_NAME, Attributes = SEGMENT_TAG_ID)]
    public class SegmentTag : TagHelper
    {
        public const string SEGMENT_TAG_NAME = "segment";
        public const string SEGMENT_TAG_ID = "target";
        private SegmentCollector _manager;

        public override int Order
        {
            get
            {
                return 2;
            }
        }

        public SegmentTag(SegmentCollector manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var id = output.Attributes[SEGMENT_TAG_ID];

            if(id == null)
            {
                throw new InvalidOperationException($"A segment must contain an attribute called {SEGMENT_TAG_ID}");
            }

            var segmentList = _manager.GetOrCreate(id.Value.ToString());
            var tagHelperOutput = new TagHelperOutput(string.Empty, output.Attributes, output.GetChildContentAsync);

            segmentList.Add(tagHelperOutput);
            output.SuppressOutput();
        }
    }

}
