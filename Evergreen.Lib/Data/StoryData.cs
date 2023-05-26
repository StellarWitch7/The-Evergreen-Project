using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evergreen.Lib.Data
{
    public class StoryData
    {
        public string StoryName { get; set; }
        public string StoryVersion { get; set; }
        public string StoryDescription { get; set; }
        public List<BlockData> StoryPoints { get; set; }
    }
}
