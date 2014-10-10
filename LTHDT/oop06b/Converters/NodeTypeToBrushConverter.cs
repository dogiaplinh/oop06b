using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Oop06b.Converters
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
                    return new SolidColorBrush(Colors.Red);

                case NodeType.Goal:
                    return new SolidColorBrush(Colors.Green);

                case NodeType.Obstacle:
                    return new SolidColorBrush(Colors.DarkGray);

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