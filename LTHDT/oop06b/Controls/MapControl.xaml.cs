using Oop06b.Models;
using Oop06b.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Oop06b.Controls
{
    /// <summary>
    /// Interaction logic for CustomCanvas.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<NodeControlViewModel>), typeof(MapControl), new PropertyMetadata(new ObservableCollection<NodeControlViewModel>(), OnItemsSourceChanged));

        public MapControl()
        {
            InitializeComponent();
            DataContextChanged += MapControl_DataContextChanged;
        }

        public ObservableCollection<NodeControlViewModel> ItemsSource
        {
            get { return (ObservableCollection<NodeControlViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); SetView(); }
        }

        public void MapControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CreateBinding();
        }

        private static void OnItemsSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MapControl map = sender as MapControl;
            if (map != null)
            {
                map.ItemsSource = (ObservableCollection<NodeControlViewModel>)e.NewValue;
            }
        }

        private void ConnectPath(List<Node> nodes)
        {
            int i = 0;
            Storyboard storyboard = new Storyboard();
            double xOld = 0, yOld = 0;
            TimeSpan time = TimeSpan.FromSeconds(0);
            foreach (var item in nodes)
            {
                Line line = new Line()
                {
                    X1 = xOld,
                    Y1 = yOld,
                    X2 = xOld,
                    Y2 = yOld,
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 2,
                };
                MainCanvas.Children.Add(line);
                MainCanvas.Resources.Add("line" + i.ToString(), line);
                i++;
                DoubleAnimationUsingKeyFrames animation1 = new DoubleAnimationUsingKeyFrames();
                EasingDoubleKeyFrame e1 = new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Value = item.X,
                };
                animation1.KeyFrames.Add(e1);
                DoubleAnimationUsingKeyFrames animation2 = new DoubleAnimationUsingKeyFrames();
                EasingDoubleKeyFrame e2 = new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Value = item.Y,
                };
                xOld = item.X;
                yOld = item.Y;
                animation2.KeyFrames.Add(e2);
                animation1.BeginTime = animation2.BeginTime = time;
                Storyboard.SetTargetProperty(animation1, new PropertyPath(Line.X2Property));
                Storyboard.SetTarget(animation1, line);
                Storyboard.SetTargetProperty(animation2, new PropertyPath(Line.Y2Property));
                Storyboard.SetTarget(animation2, line);
                storyboard.Children.Add(animation1);
                storyboard.Children.Add(animation2);
                time = time + TimeSpan.FromSeconds(0.5);
            }
            MainCanvas.Resources.Add("storyboard", storyboard);
            storyboard.Begin();
        }

        private void CreateBinding()
        {
            var binding = new Binding();
            binding.Source = this.DataContext;
            binding.Path = new PropertyPath("Nodes");
            BindingOperations.SetBinding(this, ItemsSourceProperty, binding);
        }

        private void GetLocation(Node node, out double x, out double y)
        {
            x = node.X * 3.0 / 4 * 48 + Params.MapWidth / 2 - 4;
            y = (node.X * Params.SQRT3 / 2 + node.Y * Params.SQRT3) * 24 + Params.MapHeight / 2 - 4;
        }

        private void SetView()
        {
            MainCanvas.Children.Clear();
            foreach (var item in ItemsSource)
            {
                NodeControl hexagon = new NodeControl();
                hexagon.DataContext = item;
                Canvas.SetLeft(hexagon, item.Node.X * 3.0 / 4 * 48 + Params.MapWidth / 2 - 28);
                Canvas.SetTop(hexagon, (item.Node.X * Params.SQRT3 / 2 + item.Node.Y * Params.SQRT3) * 24 + Params.MapHeight / 2 - 28);
                MainCanvas.Children.Add(hexagon);
            }
        }
    }
}