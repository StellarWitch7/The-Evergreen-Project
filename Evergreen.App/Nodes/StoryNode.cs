using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evergreen.App.Nodes
{
    public class StoryNode : NodeViewModel
    {
        public string Text { get; set; }

        public StoryNode()
        {
            this.Name = "Story Node";
            this.Text = "Empty text";
        }
    }
}
