using DynamicData;
using Evergreen.Lib.Nodes;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Evergreen.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver<IChangeSet<NodeViewModel>>
    {
        public NetworkViewModel Network = new NetworkViewModel();
        public List<MultiChoiceNode> MultiNodes = new List<MultiChoiceNode>();
        private IObservable<IChangeSet<NodeViewModel>> _nodeSelectionChanges;

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();

            //Add a starting node
            Network.Nodes.Add(new StartNode());

            //Assign the viewmodel to the view. VERY IMPORTANT!
            networkView.ViewModel = Network;

            _nodeSelectionChanges = networkView.ViewModel.SelectedNodes.Connect();
            _nodeSelectionChanges.Subscribe(this);
        }

        public NodeViewModel? SelectedNode
        {
            get { return (NodeViewModel)GetValue(SelectedNodeProperty); }
            set { SetValue(SelectedNodeProperty, value); }
        }

        public static readonly DependencyProperty SelectedNodeProperty =
            DependencyProperty.Register("SelectedNode", typeof(NodeViewModel), typeof(MainWindow), new PropertyMetadata(null));

        private void addTransition_Click(object sender, RoutedEventArgs e)
        {
            Network.Nodes.Add(new TransitionNode());
        }

        private void addChoice_Click(object sender, RoutedEventArgs e)
        {
            Network.Nodes.Add(new MultiChoiceNode());
        }

        private void newStart_Click(object sender, RoutedEventArgs e)
        {
            List<StartNode> remove = new List<StartNode>();

            foreach (var node in Network.Nodes.Items)
            {
                if (node is StartNode)
                {
                    remove.Add((StartNode)node);
                }
            }

            foreach (StartNode node in remove)
            {
                Network.Nodes.Remove(node);
            }

            Network.Nodes.Add(new StartNode());
        }

        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(IChangeSet<NodeViewModel> value)
        {
            foreach (var change in value.Flatten())
            {
                if (change.Reason == ListChangeReason.Add)
                {
                    if (networkView.ViewModel.SelectedNodes.Count == 1)
                    {
                        this.SelectedNode = change.Current;
                    } else
                    {
                        this.SelectedNode = null;
                    }
                } else
                {
                    this.SelectedNode = null;
                }
            }
        }
    }
}
