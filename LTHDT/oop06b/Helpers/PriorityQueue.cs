using System.Collections.Generic;

namespace Oop06b.Helpers
{
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private IComparer<T> comparer;
        private List<T> list = new List<T>();

        public PriorityQueue()
        {
            comparer = Comparer<T>.Default;
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count
        {
            get { return list.Count; }
        }

        public T this[int index]
        {
            get { return list[index]; }
            set
            {
                list[index] = value;
                Update(index);
            }
        }

        public void Clear()
        {
            list.Clear();
        }

        public T Peek()
        {
            if (list.Count > 0)
                return list[0];
            return default(T);
        }

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