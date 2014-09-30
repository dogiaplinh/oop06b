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

namespace oop06b.Controls
{
    /// <summary>
    /// Interaction logic for Hexagon.xaml
    /// </summary>
    public partial class Hexagon : UserControl
    {
        public Hexagon()
        {
            InitializeComponent();
        }

        private double scale;

        public double Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                this.RenderTransform = new ScaleTransform()
                {
                    CenterX = 0,
                    CenterY = 0,
                    ScaleX = scale,
                    ScaleY = scale
                };
            }
        }

        public event RoutedEventHandler OnSetStartClicked;

        public event RoutedEventHandler OnSetGoalClicked;

        private void SetStartClick(object sender, RoutedEventArgs e)
        {
            polygon.Fill = new SolidColorBrush(Colors.Red);
            if (OnSetStartClicked != null)
            {
                OnSetStartClicked(this, e);
            }
        }

        private void SetGoalClick(object sender, RoutedEventArgs e)
        {
            polygon.Fill = new SolidColorBrush(Colors.Green);
            if (OnSetGoalClicked != null)
            {
                OnSetGoalClicked(this, e);
            }
        }
    }
}