﻿using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Oop06b.Algorithm
{
    /// <summary>
    /// Class thuật toán A* đế tìm đường
    /// </summary>
    public class AStarAlgorithm
    {
        private PriorityQueue<Node> openSet = new PriorityQueue<Node>(Comparer<Node>.Create((x, y) => x.FScore.CompareTo(y.FScore)));
        private List<Node> closeSet = new List<Node>();
        private Map map;

        public AStarAlgorithm(Map map)
        {
            this.map = map;
        }

        private static List<Node> ReconstructPath(Node node)
        {
            List<Node> list = new List<Node>();
            while (node.Type != NodeType.Start)
            {
                list.Add(node);
                node = node.Previous;
            }
            list.Add(node);
            list.Reverse();
            return list;
        }

        public async Task<List<Node>> Run(CancellationToken ct)
        {
            if (map.Start == null || map.Goal == null)
                map.RandomGenerate();
            var start = map.Start;
            var goal = map.Goal;
            Node current = start;
            openSet.Clear();
            closeSet.Clear();

            current.GScore = 0;
            current.FScore = HeuristicFunction.CostEstimate(start, goal);
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
                if (current == goal)
                {
                    return ReconstructPath(current);
                    //closeSet.Add(parentNode);
                    //break;
                }
                closeSet.Add(current);
                if (current != start)
                {
                    current.Type = NodeType.CloseSet;
                }

                foreach (var node in current.Neighbors)
                {
                    if (node.Type == NodeType.Obstacle)
                        continue;
                    if (closeSet.Contains(node))
                        continue;
                    double tentative_g_score = current.GScore + 1;
                    if (!openSet.Contains(node) || tentative_g_score < node.GScore)
                    {
                        node.Previous = current;
                        node.GScore = tentative_g_score;
                        node.FScore = node.GScore + HeuristicFunction.CostEstimate(node, goal);
                        if (!openSet.Contains(node))
                        {
                            openSet.Push(node);
                            if (node != goal)
                            {
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