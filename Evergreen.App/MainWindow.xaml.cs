using DynamicData;
using Evergreen.Lib.Nodes;
using NodeNetwork.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Evergreen.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NetworkViewModel Network = new NetworkViewModel();
        public List<MultiChoiceNode> MultiNodes = new List<MultiChoiceNode>();

        public MainWindow()
        {
            InitializeComponent();

            //Add a starting node
            Network.Nodes.Add(new StartNode());

            //Assign the viewmodel to the view. VERY IMPORTANT!
            networkView.ViewModel = Network;
        }

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
    }
}
