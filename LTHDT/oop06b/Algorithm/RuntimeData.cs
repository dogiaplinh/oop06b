using De06B_Nhom02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De06B_Nhom02.Algorithm
{
    public class RuntimeData
    {
        public RuntimeData(double gScore, double fScore, Node previous)
        {
            GScore = gScore;
            FScore = fScore;
            Previous = previous;
        }

        public double FScore { get; set; }

        public double GScore { get; set; }

        public Node Previous { get; set; }
    }
}