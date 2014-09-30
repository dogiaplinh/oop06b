using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Models
{
    public class Node : IComparer<Node>, INotifyPropertyChanged
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; OnPropertyChanged("X"); }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged("Y"); }
        }

        private NodeType type;

        public NodeType Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public double GScore { get; set; }

        public double FScore { get; set; }

        public List<Node> Neighbors { get; set; }

        public int Compare(Node x, Node y)
        {
            throw new NotImplementedException();
        }

        public Node()
        {
            Type = NodeType.Normal;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public enum NodeType
    {
        Normal,
        Start,
        Goal,
    }
}