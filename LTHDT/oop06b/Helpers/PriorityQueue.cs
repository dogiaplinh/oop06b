using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Helpers
{
    /// <summary>
    /// Hàng đợi có ưu tiên
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu của phần tử</typeparam>
    internal class PriorityQueue<T>
    {
        private IComparer<T> comparer;
        private List<T> list = new List<T>();

        /// <summary>
        /// Tạo mới hàng đợi
        /// </summary>
        /// <param name="comparer">Cách thức so sánh 2 phần tử</param>
        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Lấy số phần tử của hàng đợi
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }

        /// <summary>
        /// Lấy và sửa 1 phần tử của hàng đợi
        /// </summary>
        /// <param name="index">Chỉ số của phần tử</param>
        /// <returns>Phần tử</returns>
        public T this[int index]
        {
            get { return list[index]; }
            set
            {
                list[index] = value;
                Update(index);
            }
        }

        /// <summary>
        /// Xoá hết các phần tử trong hàng đợi
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }

        /// <summary>
        /// Kiểm tra 1 phần tử có trong hàng đợi không
        /// </summary>
        /// <param name="item">Phần tử cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra</returns>
        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        /// <summary>
        /// Trả về phần tử đứng đầu hàng đợi nhưng không loại nó khỏi hàng đợi
        /// </summary>
        /// <returns>Phần tử đứng đầu</returns>
        public T Peek()
        {
            if (list.Count > 0)
                return list[0];
            return default(T);
        }

        /// <summary>
        /// Lấy ra phần tử đứng đầu của hàng đợi
        /// </summary>
        /// <returns>Phần tử đứng đầu</returns>
        public T Pop()
        {
            T result = list[0];
            int p = 0, p1, p2, pn;
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            do
            {
                pn = p;
                p1 = 2 * p + 1;
                p2 = 2 * p + 2;
                if (list.Count > p1 && Compare(p, p1) > 0)
                    p = p1;
                if (list.Count > p2 && Compare(p, p2) > 0)
                    p = p2;
                if (p == pn)
                    break;
                Swap(p, pn);
            }
            while (true);

            return result;
        }

        /// <summary>
        /// Thêm phần tử vào hàng đợi
        /// </summary>
        /// <param name="item">Phần tử cần thêm</param>
        public void Push(T item)
        {
            int p = list.Count, p2;
            list.Add(item);
            do
            {
                if (p == 0)
                    break;
                p2 = (p - 1) / 2;
                if (Compare(p, p2) < 0)
                {
                    Swap(p, p2);
                    p = p2;
                }
                else
                    break;
            }
            while (true);
        }

        private int Compare(int i, int j)
        {
            return comparer.Compare(list[i], list[j]);
        }

        private void Swap(int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private void Update(int index)
        {
            int p = index, pn;
            int p1, p2;
            do
            {
                if (p == 0)
                    break;
                p2 = (p - 1) / 2;
                if (Compare(p, p2) < 0)
                {
                    Swap(p, p2);
                    p = p2;
                }
                else
                    break;
            }
            while (true);
            if (p < index)
                return;
            do
            {
                pn = p;
                p1 = 2 * p + 1;
                p2 = 2 * p + 2;
                if (list.Count > p1 && Compare(p, p1) > 0)
                    p = p1;
                if (list.Count > p2 && Compare(p, p2) > 0)
                    p = p2;
                if (p == pn)
                    break;
                Swap(p, pn);
            }
            while (true);
        }
    }
}