using De06B_Nhom02.Helpers;
using De06B_Nhom02.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace De06B_Nhom02.Algorithm
{
    /// <summary>
    /// Class thuật toán A* đế tìm đường
    /// </summary>
    public class AStarAlgorithm
    {
        private PriorityQueue<Node> openSet;
        private List<Node> closeSet = new List<Node>();
        private Dictionary<Node, RuntimeData> runtimeData = new Dictionary<Node, RuntimeData>();
        private Map map;
        private Node start;
        private Node goal;

        public int Distance { get; private set; }

        public int VisitedNo { get; private set; }

        public AStarAlgorithm(Map map, Node start, Node goal)
        {
            this.map = map;
            this.start = start;
            this.goal = goal;
            InitRuntimeData();
            openSet = new PriorityQueue<Node>(Comparer<Node>.Create((x, y) => runtimeData[x].FScore.CompareTo(runtimeData[y].FScore)));
        }

        private Task<List<Node>> ReconstructPath(Node node)
        {
            List<Node> list = new List<Node>();
            while (node != start)
            {
                list.Add(node);
                node = runtimeData[node].Previous;
            }
            list.Add(node);
            list.Reverse();
            return Task.FromResult<List<Node>>(list);
        }

        private void InitRuntimeData()
        {
            foreach (var item in map)
            {
                runtimeData.Add(item, new RuntimeData(0, 0, null));
            }
        }

        public async Task<List<Node>> Run(CancellationToken ct)
        {
            VisitedNo = 0;
            if (start == null || goal == null)
                return null;
            Node current = start;
            openSet.Clear();
            closeSet.Clear();

            runtimeData[current].FScore = HeuristicFunction.CostEstimate(start, goal);

            openSet.Push(current);
            while (openSet.Count > 0)
            {
                try
                {
                    await Task.Delay(Params.Delay, ct);
                }
                catch (OperationCanceledException)
                {
                    return null;
                }
                current = openSet.Pop();
                VisitedNo++;
                if (current == goal)
                {
                    Distance = (int)runtimeData[current].FScore;
                    return await ReconstructPath(current);
                }
                closeSet.Add(current);
                if (current != start)
                {
                    if (current.IsNormal())
                        current.Type = NodeType.CloseSet;
                }

                foreach (var node in current.Neighbors)
                {
                    if (node.Type == NodeType.Obstacle)
                        continue;
                    if (closeSet.Contains(node))
                        continue;
                    double tentative_g_score = runtimeData[current].GScore + 1;
                    if (!openSet.Contains(node) || tentative_g_score < runtimeData[node].GScore)
                    {
                        runtimeData[node].Previous = current;
                        runtimeData[node].GScore = tentative_g_score;
                        runtimeData[node].FScore = runtimeData[node].GScore + HeuristicFunction.CostEstimate(node, goal);
                        if (!openSet.Contains(node))
                        {
                            openSet.Push(node);
                            if (node != goal)
                            {
                                if (node.IsNormal())
                                    node.Type = NodeType.OpenSet;
                            }
                        }
                    }
                    if (ct.IsCancellationRequested)
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}