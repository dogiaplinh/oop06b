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
    internal class Map : ModelBase, IEnumerable<Node>
    {
        private Node[] goals;
        private List<Node> nodes = new List<Node>();
        private Node[] starts;

        public Map()
        {
            starts = new Node[Params.MAX_THREAD];
            goals = new Node[Params.MAX_THREAD];
            createMap();
        }

        /// <summary>
        /// Lấy 1 nút có toạ độ (x, y)
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>Nút ở toạ độ (x, y)</returns>
        public Node this[int x, int y]
        {
            get
            {
                foreach (var item in nodes)
                {
                    if (item.X == x && item.Y == y)
                        return item;
                }
                return null;
            }
        }

        /// <summary>
        /// Dọn dẹp bản đồ = xoá các nút tạm thời trong khi tìm đường
        /// </summary>
        public void Clean()
        {
        }

        public Node GetGoal(int i)
        {
            if (i >= 0 && i < Params.MAX_THREAD)
                return goals[i];
            return null;
        }

        public Node GetStart(int i)
        {
            if (i >= 0 && i < Params.MAX_THREAD)
                return starts[i];
            return null;
        }

        /// <summary>
        /// Tạo bản đồ ngẫu nhiên
        /// </summary>
        public void RandomGenerate()
        {
        }

        /// <summary>
        /// Xoá toàn bộ bản đồ
        /// </summary>
        public void Reset()
        {
        }

        public void SetGoal(Node node, int i)
        {
            if (goals[i] == null)
            {
                goals[i] = node;
                goals[i].Id = i;
                node.Type = NodeType.Goal;
            }
            else
            {
                goals[i].Type = NodeType.Normal;
                goals[i] = node;
                node.Type = NodeType.Goal;
            }
        }

        public void SetStart(Node node, int i)
        {
            if (starts[i] == null)
            {
                starts[i] = node;
                starts[i].Id = i;
                node.Type = NodeType.Start;
            }
            else
            {
                starts[i].Type = NodeType.Normal;
                starts[i] = node;
                node.Type = NodeType.Start;
            }
        }

        /// <summary>
        /// Tạo bản đồ, gán giá trị cho neighbors của các nút
        /// </summary>
        private void createMap()
        {
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}