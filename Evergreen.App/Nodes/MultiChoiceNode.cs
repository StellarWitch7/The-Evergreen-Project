using DynamicData;
using Evergreen.App.Util;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Evergreen.App.Nodes
{
    public class MultiChoiceNode : StoryNode
    {
        public ValueNodeInputViewModel<bool> Begin { get; }
        public List<ValueNodeOutputViewModel<bool>> Exits = new List<ValueNodeOutputViewModel<bool>>();
        private List<string> CurrentOutputNames = new List<string>();

        public MultiChoiceNode()
        {
            this.Name = "Multi Choice Node";
            this.Text = "Empty text";

            Begin = new ValueNodeInputViewModel<bool>()
            {
                Name = "Begin choice",
                MaxConnections = 100
            };
            this.Inputs.Add(Begin);

            CheckForFullOutputs();
        }

        static MultiChoiceNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MultiChoiceNode>));
        }

        private void Update()
        {
            CheckForFullOutputs();
        }

        private void CheckForFullOutputs()
        {
            int connectedOutputs = 0;

            foreach(var output in this.Outputs.Items)
            {
                if (output.Connections.Count > 0)
                {
                    connectedOutputs++;
                }
            }

            if (connectedOutputs >= this.Outputs.Count)
            {
                CreateNewOutput();
            }
        }

        private void CreateNewOutput()
        {
            var newOutput = new ValueNodeOutputViewModel<bool>()
            {
                Name = Generators.RandomString(1, ref CurrentOutputNames, true),
                MaxConnections = 1,
                Value = Observable.Return(true)
            };
            this.Exits.Add(newOutput);
            this.Outputs.Add(newOutput);
        }
    }
}
