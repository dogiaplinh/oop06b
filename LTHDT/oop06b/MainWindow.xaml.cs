﻿using Oop06b.Controls;
using Oop06b.Models;
using Oop06b.ViewModels;
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