using De06B_Nhom02.Models;
using System;

namespace De06B_Nhom02.Algorithm
{
    public static class HeuristicFunction
    {
        public static double CostEstimate(Node a, Node b)
        {
            double h = Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.X + a.Y - b.X - b.Y);
            return h;
        }
    }
}