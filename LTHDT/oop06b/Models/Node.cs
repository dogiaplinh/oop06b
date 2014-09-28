using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Models
{
    public class Node : IComparer<Node>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public NodeType Type { get; set; }

        public double GScore { get; set; }

        public double FScore { get; set; }

        public List<Node> Neighbors { get; set; }

        public int Compare(Node x, Node y)
        {
            throw new NotImplementedException();
        }
    }

    public enum NodeType
    {
        Normal,
        Start,
        Goal,
    }
}