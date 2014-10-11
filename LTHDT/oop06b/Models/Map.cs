using Oop06b.Controls;
using Oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop06b.Models
{
    public class Map : ModelBase, IEnumerable<Node>
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

        public void Clean()
        {
            foreach (var item in nodes)
            {
                if (item.Type == NodeType.OpenSet || item.Type == NodeType.CloseSet)
                    item.Reset();
            }
            MapControl.Instance.ClearPath();
        }

        public void Clear()
        {
            foreach (var item in nodes)
            {
                item.Reset();
            }
            start = null;
            goal = null;
            MapControl.Instance.ClearPath();
        }

        public void RandomGenerate()
        {
            Clear();
            for (int i = 0; i < nodes.Count / 2; i++)
            {
                int a = random.Next(nodes.Count);
                nodes[a].Type = NodeType.Obstacle;
            }
            int b = random.Next(nodes.Count);
            Start = nodes[b];
            int c;
            do
            {
                c = random.Next(nodes.Count);
                if (Start != nodes[c])
                    Goal = nodes[c];
            }
            while (b == c);
        }

        private void CreateMap()
        {
            int a = (int)(1000 / Params.Scale / 300 / 2 * 4 / 3) - 1;
            for (int i = -a; i <= a; i++)
            {
                int start = (int)Math.Ceiling((-Params.MapHeight / 300 / Params.Scale - 1 - i * Params.SQRT3 / 2) / Params.SQRT3) + 1;
                int end = (int)Math.Floor((Params.MapHeight / 300 / Params.Scale - 1 - i * Params.SQRT3 / 2) / Params.SQRT3);
                for (int j = start; j <= end; j++)
                {
                    nodes.Add(new Node() { X = i, Y = j });
                }
            }
            Node node;
            // Add neighbors to each node
            foreach (var item in nodes)
            {
                if ((node = this[item.X - 1, item.Y]) != null)
                {
                    item.Neighbors.Add(node);
                }
                if ((node = this[item.X, item.Y - 1]) != null)
                {
                    item.Neighbors.Add(node);
                }
                if ((node = this[item.X + 1, item.Y - 1]) != null)
                {
                    item.Neighbors.Add(node);
                }
                if ((node = this[item.X + 1, item.Y]) != null)
                {
                    item.Neighbors.Add(node);
                }
                if ((node = this[item.X, item.Y + 1]) != null)
                {
                    item.Neighbors.Add(node);
                }
                if ((node = this[item.X - 1, item.Y + 1]) != null)
                {
                    item.Neighbors.Add(node);
                }
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}