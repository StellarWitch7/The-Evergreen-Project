using Evergreen.Lib.Nodes;
using System.Numerics;

namespace Evergreen.Lib.Data
{
    public class NodeData
    {
        public int Id { get; set; }
        public Vector2 Position { get; set; }
        public StoryNode Node { get; set; }
    }
}
