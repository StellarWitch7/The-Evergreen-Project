using Evergreen.App.Nodes;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Evergreen.App.Data
{
    public class NodeData
    {
        public int Id { get; set; }
        public Vector2 Position { get; set; }
        public StoryNode Node { get; set; }
    }
}
