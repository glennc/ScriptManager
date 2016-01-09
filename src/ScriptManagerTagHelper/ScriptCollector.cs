using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptManagerTagHelper
{
    public class ScriptCollector
    {
        public List<TagHelperOutput> Scripts { get; set; }
        public ScriptCollector()
        {
            this.Scripts = new List<TagHelperOutput>();
        }
    }
}