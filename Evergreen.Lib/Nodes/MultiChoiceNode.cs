using DynamicData;
using Evergreen.Lib.Nodes;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Evergreen.Lib.Nodes
{
    public class MultiChoiceNode : StoryNode
    {
        private int _outputCount = 2;
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

            CheckOutputs();
        }

        public int OutputCount
        {
            get
            {
                return _outputCount;
            }
            set
            {
                _outputCount = value;
                CheckOutputs();
            }
        }

        static MultiChoiceNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new StoryNodeView(), typeof(IViewFor<MultiChoiceNode>));
        }

        private void CheckOutputs()
        {
            bool confirmed = false;

            while (this.Outputs.Count < OutputCount)
            {
                CreateNewOutput();
            }

            while (this.Outputs.Count > OutputCount)
            {
                bool removeNamed = true;

                foreach (var output in this.Outputs.Items)
                {
                    if (output.Name == "new")
                    {
                        removeNamed = false;
                    }
                }

                if (removeNamed && !confirmed)
                {
                    if (MessageBox.Show("Reducing the amount of outputs will clear some of their names. Continue?",
                        "test", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                    {
                        OutputCount = this.Outputs.Count;
                        return;
                    }
                    else
                    {
                        confirmed = true;
                    }
                }

                RemoveExtraOutput(removeNamed);
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

        private void RemoveExtraOutput(bool clearNamed)
        {
            var remove = new NodeOutputViewModel();

            foreach (var output in this.Outputs.Items)
            {
                if (output.Name == "new")
                {
                    remove = output;
                    break;
                }
                else if (clearNamed)
                {
                    remove = output;
                    break;
                }
            }

            this.Outputs.Remove(remove);
        }
    }
}
