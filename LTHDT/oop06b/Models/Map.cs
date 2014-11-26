using De06B_Nhom02.Controls;
using De06B_Nhom02.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De06B_Nhom02.Models
{
    public class Map : IEnumerable<Node>
    {
        private Node[] goals;
        private List<Node> nodes = new List<Node>();
        private Node[] starts;

        public Map()
        {
            goals = new Node[5];
            starts = new Node[5];
            InitMap();
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
            for (int i = 0; i < 5; i++)
            {
                starts[i] = goals[i] = null;
            }
            MapControl.Instance.ClearPath();
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        public Node GetGoal(int i)
        {
            return goals[i];
        }

        public Node GetStart(int i)
        {
            return starts[i];
        }

        public void RandomGenerate(int number)
        {
            Random random = new Random();
            Clear();
            for (int i = 0; i < nodes.Count / 2; i++)
            {
                int a = random.Next(nodes.Count);
                nodes[a].Type = NodeType.Obstacle;
            }
            List<int> list = new List<int>();
            for (int i = 0; i < nodes.Count; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < number; i++)
            {
                int b = list[random.Next(list.Count)];
                SetStart(i, nodes[b]);
                list.RemoveAt(b);
                b = list[random.Next(list.Count)];
                SetGoal(i, nodes[b]);
                list.RemoveAt(b);
            }
        }

        public void SetGoal(int i, Node node)
        {
            if (goals[i] == null)
            {
                goals[i] = node;
                node.Id = i;
                node.Type = NodeType.Goal;
            }
            else
            {
                goals[i].Type = NodeType.Normal;
                goals[i] = node;
                node.Type = NodeType.Goal;
            }
        }

        public void SetStart(int i, Node node)
        {
            if (starts[i] == null)
            {
                starts[i] = node;
                node.Id = i;
                node.Type = NodeType.Start;
            }
            else
            {
                starts[i].Type = NodeType.Normal;
                starts[i] = node;
                node.Type = NodeType.Start;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void InitMap()
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
    }
}