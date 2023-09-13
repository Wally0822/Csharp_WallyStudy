namespace Csharp_WallyStudy.DataStructure
{
    public class MyQueue<T> where T : IComparable<T>
    {
        private MyArray<T> _items;

        public MyQueue()
        {
            _items = new MyArray<T>();
        }

        public int Count => _items.Count;

        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T frontItem = _items[0];
            _items.RemoveAt(0);
            return frontItem;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _items[0];
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }
    }

    public class MyQueueDemo
    {
        public void Run()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine($"Queue count: {queue.Count}");
            Console.WriteLine($"Front item: {queue.Peek()}");
            Console.WriteLine($"Dequeued item: {queue.Dequeue()}");
            Console.WriteLine($"Queue count after dequeue: {queue.Count}");

            queue.Clear();
            Console.WriteLine($"Queue count after clearing: {queue.Count}");
        }
    }
}