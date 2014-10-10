using Oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop06b.Models
{
    public class Map : ModelBase
    {
        private Node goal;
        private List<Node> nodes = new List<Node>();
        private Random random = new Random();
        private Node start;

        public Map()
        {
            CreateMap();
        }

        public Node Goal
        {
            get { return goal; }
            set
            {
                if (goal != value)
                {
                    if (goal != null)
                        goal.Type = NodeType.Normal;
                    goal = value;
                    if (goal != null)
                        goal.Type = NodeType.Goal;
                    OnPropertyChanged("Goal");
                }
            }
        }

        public List<Node> Nodes
        {
            get { return nodes; }
        }

        public Node Start
        {
            get { return start; }
            set
            {
                if (start != value)
                {
                    if (start != null)
                        start.Type = NodeType.Normal;
                    start = value;
                    if (start != null)
                        start.Type = NodeType.Start;
                    OnPropertyChanged("Start");
                }
            }
        }

        public Node this[int i, int j]
        {
            get
            {
                foreach (var item in nodes)
                {
                    if (item.X == i && item.Y == j)
                        return item;
                }
                return null;
            }
        }

        public void Clear()
        {
        }

        public void RandomGenerate()
        {
        }

        private void CreateMap()
        {
            for (int i = -13; i <= 13; i++)
            {
                int start = (int)Math.Ceiling(-i / 2.0 - 6.7);
                int end = (int)Math.Floor(-i / 2.0 + 6.7);
                for (int j = start; j <= end; j++)
                {
                    Nodes.Add(new Node() { X = i, Y = j });
                }
            }
        }
    }
}