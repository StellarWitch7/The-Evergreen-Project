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
    public class MultiChoiceNode : StoryNode
    {
        public ValueNodeInputViewModel<bool> Begin { get; }
        public ValueNodeOutputViewModel<bool> ChoiceOne { get; }
        public ValueNodeOutputViewModel<bool> ChoiceTwo { get; }
        public ValueNodeOutputViewModel<bool> ChoiceThree { get; }
        public ValueNodeOutputViewModel<bool> ChoiceFour { get; }
        public ValueNodeOutputViewModel<bool> ChoiceFive { get; }
        public ValueNodeOutputViewModel<bool> ChoiceSix { get; }

        public MultiChoiceNode()
        {
            this.Name = "Multi Choice Node";
            this.Text = "Empty text";

            Begin = new ValueNodeInputViewModel<bool>()
            {
                Name = "Begin choice"
            };
            this.Inputs.Add(Begin);

            ChoiceOne = new ValueNodeOutputViewModel<bool>()
            {
                Name = "A",
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceOne);

            ChoiceTwo = new ValueNodeOutputViewModel<bool>()
            {
                Name = "B",
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceTwo);

            ChoiceThree = new ValueNodeOutputViewModel<bool>()
            {
                Name = "C",
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceThree);

            ChoiceFour = new ValueNodeOutputViewModel<bool>()
            {
                Name = "D",
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceFour);

            ChoiceFive = new ValueNodeOutputViewModel<bool>()
            {
                Name = "E",
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceFive);

            ChoiceSix = new ValueNodeOutputViewModel<bool>()
            {
                Name = "F",
                Value = Observable.Return(true)
            };
            this.Outputs.Add(ChoiceSix);
        }

        static MultiChoiceNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MultiChoiceNode>));
        }
    }
}
