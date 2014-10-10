using Oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop06b.Models
{
    /// <summary>
    /// Tập các loại của nút
    /// </summary>
    public enum NodeType
    {
        Normal,
        Start,
        Goal,
        Obstacle,
    }

    /// <summary>
    /// Class của các nút trong bản đồ
    /// </summary>
    public class Node : ModelBase, IComparer<Node>
    {
        private NodeType type;
        private int x;
        private int y;

        public Node()
        {
            Type = NodeType.Normal;
        }

        public double FScore { get; set; }

        public double GScore { get; set; }

        public List<Node> Neighbors { get; set; }

        public Node Previous { get; set; }

        public NodeType Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
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

        public int Compare(Node x, Node y)
        {
            throw new NotImplementedException();
        }
    }
}