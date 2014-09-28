using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Models
{
    public class Map
    {
        private List<Node> map = new List<Node>();
        private Random random = new Random();
        private Node start;
        private Node goal;

        public Node this[int i, int j]
        {
            get
            {
                foreach (var item in map)
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
    }
}