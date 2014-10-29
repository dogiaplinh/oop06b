using oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Models
{
    /// <summary>
    /// Lớp của các nút trong mạng
    /// </summary>
    internal class Node : ModelBase
    {
        private int x;
        private int y;

        public Node()
        {
        }

        public int X
        {
            get { return x; }
            set { x = value; OnPropertyChanged("X"); }
        }

        public int Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged("Y"); }
        }
    }
}