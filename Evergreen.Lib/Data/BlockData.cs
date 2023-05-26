using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evergreen.Lib.Data
{
    public class BlockData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> TextBlock { get; set; }
        public List<ProgressTarget> Targets { get; set; }
    }
}
