using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Oop06b.Models
{
    /// <summary>
    /// Class chứa toàn bộ các thông số sử dụng trong project
    /// </summary>
    public struct Params
    {
        public static double SQRT3 = Math.Sqrt(3);
        public static double MapHeight = 600;
        public static double MapWidth = 1000;
        public static double Scale = 0.1;
        public static int Delay = 64;
        public static Color[] LineColor = { Colors.DarkRed, Colors.DarkGreen, Colors.DarkOrange, Colors.DarkViolet, Colors.Brown };
    }
}