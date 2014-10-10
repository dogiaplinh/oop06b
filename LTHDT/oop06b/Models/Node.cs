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
        OpenSet,
        CloseSet,
    }

    /// <summary>
    /// Class của các nút trong bản đồ
    /// </summary>
    public class Node : ModelBase, IComparer<Node>, IComparable<Node>
    {
        private NodeType type;
        private List<Node> neighbors = new List<Node>();

        public Node()
        {
            Type = NodeType.Normal;
        }

        public double FScore { get; set; }

        public double GScore { get; set; }

        public List<Node> Neighbors
        {
            get { return neighbors; }
        }

        public Node Previous { get; set; }

        public NodeType Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Compare(Node x, Node y)
        {
            if (x.X == y.X)
            {
                if (x.Y == y.Y)
                {
                    return 0;
                }
            }
            return 1;
        }

        public void Reset()
        {
            Type = NodeType.Normal;
            FScore = 0;
            GScore = 0;
            Previous = null;
        }

        public int CompareTo(Node other)
        {
            return Compare(this, other);
        }
    }
}