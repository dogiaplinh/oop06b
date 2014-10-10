namespace Oop06b.Helpers
{
    public interface IPriorityQueue<T>
    {
        T Peek();

        T Pop();

        void Push(T item);
    }
}