using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptManagerTagHelper
{
    public class SegmentCollector
    {
        public List<TagHelperOutput> Scripts { get; set; }
        public SegmentCollector()
        {
            this.Scripts = new List<TagHelperOutput>();
        }
    }
}