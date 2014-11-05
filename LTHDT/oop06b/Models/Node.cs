using oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Models
{
    internal enum NodeType
    {
        Start,
        Goal,
        Normal,
        Ostacle,
        OpenSet,
        CloseSet,
    }

    /// <summary>
    /// Lớp của các nút trong mạng
    /// </summary>
    internal class Node : ModelBase
    {
        private int id;
        private List<Node> neighbors = new List<Node>();
        private NodeType type;

        public Node()
        {
        }

        /// <summary>
        /// ID của nút, để phân biệt các nút start và goal
        /// </summary>
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

        /// <summary>
        /// Xoá ô về trạng thái gốc
        /// </summary>
        public void Reset()
        {
            Type = NodeType.Normal;
        }
    }
}