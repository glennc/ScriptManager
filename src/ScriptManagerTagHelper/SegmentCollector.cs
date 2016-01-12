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
        public Dictionary<string, List<TagHelperOutput>> Segments { get; set; }

        public SegmentCollector()
        {
            this.Segments = new Dictionary<string, List<TagHelperOutput>>();
        }

        public List<TagHelperOutput> GetOrCreate(string segmentId)
        {
            List<TagHelperOutput> outputList = GetContent(segmentId);
            if (outputList == null)
            {
                outputList = new List<TagHelperOutput>();
                Segments.Add(segmentId, outputList);
            }
            return outputList;
        }

        internal List<TagHelperOutput> GetContent(string target)
        {
            List<TagHelperOutput> outputList = null;
            Segments.TryGetValue(target, out outputList);
            return outputList;
        }
    }
}