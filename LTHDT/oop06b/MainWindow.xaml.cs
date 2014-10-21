using Oop06b.Models;
using Oop06b.ViewModels;
using System.Windows;

namespace Oop06b
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