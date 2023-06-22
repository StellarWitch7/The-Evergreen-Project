using Evergreen.Lib.Nodes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DynamicData;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Windows.Controls;
using System.Reactive.Linq;

namespace Evergreen.Lib
{
    public partial class StoryNodeView : UserControl, IViewFor<StoryNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(StoryNode), typeof(StoryNodeView), new PropertyMetadata(null));

        public StoryNode ViewModel
        {
            get => (StoryNode)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (StoryNode)value;
        }
        #endregion

        public StoryNodeView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}