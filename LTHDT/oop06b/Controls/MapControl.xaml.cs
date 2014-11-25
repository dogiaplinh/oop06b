using De06B_Nhom02.Helpers;
using De06B_Nhom02.Models;
using De06B_Nhom02.ViewModels;
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

namespace De06B_Nhom02.Controls
{
    /// <summary>
    /// Interaction logic for CustomCanvas.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        private double timeDelay = 0.15;
        private List<NodeControl> nodes = new List<NodeControl>();

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<NodeControlViewModel>), typeof(MapControl), new PropertyMetadata(new ObservableCollection<NodeControlViewModel>(), OnItemsSourceChanged));

        public MapControl()
        {
            Instance = this;
            InitializeComponent();
            DataContextChanged += MapControl_DataContextChanged;
        }

        public static MapControl Instance { get; private set; }

        public ObservableCollection<NodeControlViewModel> ItemsSource
        {
            get { return (ObservableCollection<NodeControlViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); SetView(); }
        }

        public void ClearPath()
        {
            SetView();
        }

        public void ConnectPath(List<Node> nodes, int index)
        {
            Color color = Params.LineColor[index];
            List<Line> lines = new List<Line>();
            var start = nodes[0];
            var goal = nodes[nodes.Count - 1];
            double center = -200 * Params.Scale / (1 - Params.Scale * 4);
            var scaleTransform = new ScaleTransform()
            {
                CenterX = center,
                CenterY = center * 2,
                ScaleX = Params.Scale * 4,
                ScaleY = Params.Scale * 4,
            };
            int i = 0;
            Storyboard storyboard = new Storyboard();
            double xOld = 0, yOld = 0;
            TimeSpan time = TimeSpan.FromSeconds(0);
            foreach (var node in nodes)
            {
                Line line = new Line()
                {
                    X1 = xOld,
                    Y1 = yOld,
                    X2 = xOld,
                    Y2 = yOld,
                    Stroke = new SolidColorBrush(color),
                    StrokeThickness = 2,
                };
                GetLocation(node, out xOld, out yOld);
                if (node == start)
                {
                    // Add pushpin
                    AddPushpin(scaleTransform, storyboard, xOld, yOld, time);
                    i++;
                    time += TimeSpan.FromSeconds(timeDelay);
                    continue;
                }
                MainCanvas.Children.Add(line);
                lines.Add(line);
                line.MouseMove += (sender, e) =>
                    {
                        foreach (var item in lines)
                        {
                            MainCanvas.Children.Remove(item);
                            item.StrokeThickness = 4;
                            MainCanvas.Children.Add(item);
                        }
                    };
                line.MouseLeave += (sender, e) =>
                {
                    foreach (var item in lines)
                    {
                        MainCanvas.Children.Remove(item);
                        item.StrokeThickness = 2;
                        MainCanvas.Children.Add(item);
                    }
                };
                if (!MainCanvas.Resources.Contains("line" + i.ToString()))
                    MainCanvas.Resources.Add("line" + i.ToString(), line);
                else MainCanvas.Resources["line" + i.ToString()] = line;
                DoubleAnimationUsingKeyFrames animation1 = new DoubleAnimationUsingKeyFrames();
                EasingDoubleKeyFrame e1 = new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(timeDelay),
                    Value = xOld,
                };
                animation1.KeyFrames.Add(e1);
                DoubleAnimationUsingKeyFrames animation2 = new DoubleAnimationUsingKeyFrames();
                EasingDoubleKeyFrame e2 = new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(timeDelay),
                    Value = yOld,
                };
                animation2.KeyFrames.Add(e2);
                animation1.BeginTime = animation2.BeginTime = time;
                Storyboard.SetTargetProperty(animation1, new PropertyPath(Line.X2Property));
                Storyboard.SetTarget(animation1, line);
                Storyboard.SetTargetProperty(animation2, new PropertyPath(Line.Y2Property));
                Storyboard.SetTarget(animation2, line);
                storyboard.Children.Add(animation1);
                storyboard.Children.Add(animation2);
                time = time + TimeSpan.FromSeconds(timeDelay);
                i++;
                if (node == goal)
                {
                    AddPushpin(scaleTransform, storyboard, xOld, yOld, time);
                }
            }
            if (!MainCanvas.Resources.Contains("storyboard"))
                MainCanvas.Resources.Add("storyboard", storyboard);
            else MainCanvas.Resources["storyboard"] = storyboard;
            storyboard.Begin();
        }

        private void AddPushpin(ScaleTransform scaleTransform, Storyboard storyboard, double x, double y, TimeSpan beginTime)
        {
            var p = new PushPin();
            p.RenderTransform = scaleTransform;
            Canvas.SetLeft(p, x);
            Canvas.SetTop(p, y);
            MainCanvas.Children.Add(p);
            if (!MainCanvas.Resources.Contains("pin"))
                MainCanvas.Resources.Add("pin", p);
            else MainCanvas.Resources["pin"] = p;
            var animation3 = new BooleanAnimationUsingKeyFrames();
            var e3 = new DiscreteBooleanKeyFrame()
            {
                KeyTime = beginTime,
                Value = false,
            };
            var e4 = new DiscreteBooleanKeyFrame()
            {
                KeyTime = beginTime + TimeSpan.FromSeconds(timeDelay),
                Value = true,
            };
            animation3.KeyFrames.Add(e3);
            animation3.KeyFrames.Add(e4);
            Storyboard.SetTargetProperty(animation3, new PropertyPath(PushPin.IsOpenProperty));
            Storyboard.SetTarget(animation3, p);
            storyboard.Children.Add(animation3);
        }

        private void MapControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
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

        private void CreateBinding()
        {
            var binding = new Binding();
            binding.Source = this.DataContext;
            binding.Path = new PropertyPath("Nodes");
            BindingOperations.SetBinding(this, ItemsSourceProperty, binding);
        }

        private static void GetLocation(Node node, out double x, out double y)
        {
            x = node.X * 225 * Params.Scale + Params.MapWidth / 2;
            y = (node.X * Params.SQRT3 / 2 + node.Y * Params.SQRT3) * 150 * Params.Scale + Params.MapHeight / 2;
        }

        private void SetView()
        {
            MainCanvas.Children.Clear();
            if (nodes.Count == 0)
                foreach (var item in ItemsSource)
                {
                    NodeControl hexagon = new NodeControl();
                    nodes.Add(hexagon);
                    hexagon.DataContext = item;
                    Canvas.SetLeft(hexagon, item.Node.X * 225 * Params.Scale + Params.MapWidth / 2 - 150 * Params.Scale);
                    Canvas.SetTop(hexagon, (item.Node.X * Params.SQRT3 / 2 + item.Node.Y * Params.SQRT3 - 1) * 150 * Params.Scale + Params.MapHeight / 2);
                    MainCanvas.Children.Add(hexagon);
                }
            else
                foreach (var item in nodes)
                {
                    MainCanvas.Children.Add(item);
                }
        }
    }
}