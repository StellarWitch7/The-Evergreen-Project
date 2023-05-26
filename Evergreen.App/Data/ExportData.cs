using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evergreen.App.Data
{
    public class ExportData
    {
        public string GameName { get; set; }
        public string GameVersion { get; set; }
        public string GameDescription { get; set; }
        public List<BlockData> StoryPoints { get; set; }
    }
}
