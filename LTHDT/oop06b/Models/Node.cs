using De06B_Nhom02.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De06B_Nhom02.Models
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
    public class Node : BindableBase
    {
        private int id;
        private List<Node> neighbors = new List<Node>();

        private NodeType type;

        public Node()
        {
            Type = NodeType.Normal;
        }

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public List<Node> Neighbors
        {
            get { return neighbors; }
        }

        public NodeType Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void Reset()
        {
            Type = NodeType.Normal;
        }

        public bool IsNormal()
        {
            if (type == NodeType.Goal || type == NodeType.Start)
                return false;
            return true;
        }
    }
}