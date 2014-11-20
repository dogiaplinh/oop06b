using Oop06b.Models;
using System;
using System.Windows.Data;

namespace Oop06b.Converters
{
    public class NodeTypeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = (NodeType)value;
            switch (type)
            {
                case NodeType.Normal:
                    return false;

                case NodeType.Obstacle:
                    return true;

                default:
                    return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return NodeType.Obstacle;
            return NodeType.Normal;
        }
    }
}