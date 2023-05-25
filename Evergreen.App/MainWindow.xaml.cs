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

        public MainWindow()
        {
            InitializeComponent();

            //Assign the viewmodel to the view. VERY IMPORTANT!
            networkView.ViewModel = Network;
        }
    }
}
