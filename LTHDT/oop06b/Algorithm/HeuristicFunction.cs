using De06B_Nhom02.Models;
using System;

namespace De06B_Nhom02.Algorithm
{
    public static class HeuristicFunction
    {
        public static double CostEstimate(Node a, Node b)
        {
            double x = a.X - b.X;
            double y = a.Y - b.Y;
            double z = a.X + a.Y - b.X - b.Y;
            double h = Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
            double k = Math.Sqrt(x * x + y * y + x * y);
            return h / 2 + k / 4;
        }
    }
}