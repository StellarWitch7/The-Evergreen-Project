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
    public class BooleanChoiceNode : StoryNode
    {
        public ValueNodeInputViewModel<bool> Begin { get; }
        public ValueNodeOutputViewModel<bool> ChoiceOne { get; }
        public ValueNodeOutputViewModel<bool> ChoiceTwo { get; }

        public BooleanChoiceNode()
        {
            this.Name = "Boolean Choice Node";
            this.Text = "Empty text";

            Begin = new ValueNodeInputViewModel<bool>()
            {
                Name = "Begin choice",
                MaxConnections = 100
            };
            this.Inputs.Add(Begin);

            ChoiceOne = new ValueNodeOutputViewModel<bool>()
            {
                Name = "A",
                MaxConnections = 1,
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceOne);

            ChoiceTwo = new ValueNodeOutputViewModel<bool>()
            {
                Name = "B",
                MaxConnections = 1,
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceTwo);
        }

        static BooleanChoiceNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<BooleanChoiceNode>));
        }
    }
}
