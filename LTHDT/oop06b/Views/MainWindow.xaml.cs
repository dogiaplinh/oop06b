using De06B_Nhom02.Models;
using De06B_Nhom02.ViewModels;
using System.Windows;

namespace De06B_Nhom02.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewmodel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            Params.MapHeight = MapLayout.ActualHeight;
            Params.MapWidth = MapLayout.ActualWidth;
            viewmodel = new MainWindowViewModel();
            this.DataContext = viewmodel;
        }
    }
}