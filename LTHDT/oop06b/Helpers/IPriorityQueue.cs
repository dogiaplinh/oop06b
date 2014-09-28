using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.Helpers
{
    public interface IPriorityQueue<T>
    {
        T Peek();

        T Pop();

        void Push(T item);
    }
}