using DynamicData;
using Evergreen.App.Nodes;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void addBoolChoice_Click(object sender, RoutedEventArgs e)
        {
            Network.Nodes.Add(new BooleanChoiceNode());
        }

        private void addTransition_Click(object sender, RoutedEventArgs e)
        {
            Network.Nodes.Add(new TransitionNode());
        }

        private void addMultiChoice_Click(object sender, RoutedEventArgs e)
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
