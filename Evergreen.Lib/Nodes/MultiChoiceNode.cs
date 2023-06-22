using DynamicData;
using Evergreen.Lib.Nodes;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Threading;

namespace Evergreen.Lib.Nodes
{
    public class MultiChoiceNode : StoryNode
    {
        public ValueNodeInputViewModel<bool> Begin { get; }

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

            //Begin updates
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0);
            dispatcherTimer.Start();
        }

        static MultiChoiceNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new StoryNodeView(), typeof(IViewFor<MultiChoiceNode>));
        }

        private void Update()
        {
            CheckOutputs();
        }

        private void CheckOutputs()
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
            else if (connectedOutputs < this.Outputs.Count - 1)
            {
                RemoveExtraOutput();
            }
        }

        private void CreateNewOutput()
        {
            var newOutput = new ValueNodeOutputViewModel<bool>()
            {
                Name = "new",
                MaxConnections = 1,
                Value = Observable.Return(true)
            };

            this.Outputs.Add(newOutput);
        }

        private void RemoveExtraOutput()
        {
            var remove = new NodeOutputViewModel();

            foreach (var output in this.Outputs.Items)
            {
                if (output.Connections.Count <= 0)
                {
                    remove = output;
                    break;
                }
            }

            this.Outputs.Remove(remove);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Update();
        }
    }
}
