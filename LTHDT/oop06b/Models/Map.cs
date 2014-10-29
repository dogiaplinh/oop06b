using oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Models
{
    /// <summary>
    /// Class bản đồ toàn mạng
    /// </summary>
    internal class Map : ModelBase
    {
        private List<Node> nodes = new List<Node>();

        public Map()
        {
        }
    }
}