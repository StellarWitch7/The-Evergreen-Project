using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evergreen.App.Data
{
    public class ProjectData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<NodeData> Nodes { get; set; }
    }
}
