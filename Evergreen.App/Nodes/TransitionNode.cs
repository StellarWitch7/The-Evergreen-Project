using DynamicData;
using DynamicData.Binding;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
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
    public class TransitionNode : StoryNode
    {
        public ValueNodeInputViewModel<bool> Begin { get; }
        public ValueNodeOutputViewModel<bool> End { get; }

        public TransitionNode()
        {
            this.Name = "Transition Node";
            this.Text = "Empty text";

            Begin = new ValueNodeInputViewModel<bool>()
            {
                Name = "Begin transition",
                MaxConnections = 100
            };
            this.Inputs.Add(Begin);

            End = new ValueNodeOutputViewModel<bool>()
            {
                Name = "End transition",
                MaxConnections = 1,
                Value = Observable.Return(true)
            };
            this.Outputs.Add(End);
        }

        static TransitionNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<TransitionNode>));
        }
    }
}
