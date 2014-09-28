using oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Models
{
    /// <summary>
    /// Class thuật toán A* đế tìm đường
    /// </summary>
    public class AStar
    {
        private Node start;
        private Node goal;
        private PriorityQueue<Node> openSet = new PriorityQueue<Node>();
        private List<Node> closeSet = new List<Node>();
        private Map map;

        public AStar(Map map, Node start, Node goal)
        {
            this.map = map;
            this.start = start;
            this.goal = goal;
        }

        public List<Node> Run()
        {
            throw new NotImplementedException();
        }
    }
}