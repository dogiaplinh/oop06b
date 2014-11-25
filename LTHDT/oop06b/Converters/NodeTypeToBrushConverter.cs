using De06B_Nhom02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace De06B_Nhom02.Converters
{
    public class NodeTypeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = (NodeType)value;
            switch (type)
            {
                case NodeType.Normal:
                    return new SolidColorBrush(Colors.White);

                case NodeType.Start:
                    return new SolidColorBrush(Colors.Orange);

                case NodeType.Goal:
                    return new SolidColorBrush(Color.FromArgb(255, 30, 236, 30));

                case NodeType.Obstacle:
                    return new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));

                case NodeType.OpenSet:
                    return new SolidColorBrush(Color.FromArgb(255, 100, 100, 255));

                case NodeType.CloseSet:
                    return new SolidColorBrush(Colors.LightBlue);

                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
}