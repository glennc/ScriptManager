using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptManagerTagHelper
{
    public class DistinctTracker
    {
        public List<string> DistinctTagsRendered { get; set; }
        public DistinctTracker()
        {
            DistinctTagsRendered = new List<string>();
        }
    }
}
