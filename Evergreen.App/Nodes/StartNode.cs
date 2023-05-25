using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evergreen.App.Nodes
{
    public class StartNode : StoryNode
    {
        public ValueNodeOutputViewModel<bool> Start { get; }

        public StartNode()
        {
            this.Name = "Start Node";
            this.Text = "Empty text";

            Start = new ValueNodeOutputViewModel<bool>()
            {
                Name = "End transition",
                Value = Observable.Return(true)
            };
            this.Outputs.Add(Start);
        }

        static StartNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<StartNode>));
        }
    }
}
