using Oop06b.Models;
using Oop06b.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Oop06b.Controls
{
    /// <summary>
    /// Interaction logic for Hexagon.xaml
    /// </summary>
    public partial class NodeControl : UserControl
    {
        public NodeControl()
        {
            InitializeComponent();
        }

        public static NodeType CurrentType { get; set; }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var type = (DataContext as NodeControlViewModel).Node.Type;
                if (type != NodeType.Start && type != NodeType.Goal)
                    (DataContext as NodeControlViewModel).Node.Type = CurrentType;
            }
        }
    }
}