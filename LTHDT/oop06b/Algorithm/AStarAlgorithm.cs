using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop06b.Algorithm
{
    /// <summary>
    /// Class thuật toán A* đế tìm đường
    /// </summary>
    public class AStarAlgorithm
    {
        private Node start;
        private Node goal;
        private PriorityQueue<Node> openSet = new PriorityQueue<Node>();
        private List<Node> closeSet = new List<Node>();
        private Map map;
        private HeuristicFunction function = new HeuristicFunction();

        public AStarAlgorithm(Map map)
        {
            this.map = map;
            this.start = map.Start;
            this.goal = map.Goal;
        }

        public List<Node> Run()
        {
            throw new NotImplementedException();
        }
    }
}