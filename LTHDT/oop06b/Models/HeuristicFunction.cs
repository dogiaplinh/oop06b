using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop06b.Models
{
    public class HeuristicFunction
    {
        public double CostEstimate(Node a, Node b)
        {
            double h = Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.X + a.Y - b.X - b.Y);
            return h;
        }
    }
}