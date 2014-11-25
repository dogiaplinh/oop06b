using De06B_Nhom02.Models;
using De06B_Nhom02.ViewModels;
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

namespace De06B_Nhom02.Controls
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

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var viewmodel = DataContext as NodeControlViewModel;
                viewmodel.MouseMoveCommand.Execute(null);
            }
        }
    }
}