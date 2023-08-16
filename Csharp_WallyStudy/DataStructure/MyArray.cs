namespace Csharp_WallyStudy.DataStructure;

public class MyArray<T> where T : IComparable<T>
{
    private Node _head;
    private int _count;

    private class Node
    {
        public T Value;
        public Node Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public MyArray()
    {
        _head = null;
        _count = 0;
    }

    public int Count => _count;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node current = _head;

            for (int i = 0; i < index; ++i)
            {
                current = current.Next;
            }

            return current.Value;
        }
        set
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node current = _head;

            for (int i = 0; i < index; ++i)
            {
                current = current.Next;
            }

            current.Value = value;
        }
    }

    public void Add(T value)
    {
        Node newNode = new Node(value);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        _count++;
    }

    public void Sort()
    {
        _head = MergeSort(_head);
    }

    private Node MergeSort(Node head)
    {
        if (head == null || head.Next == null)
        {
            return head;
        }

        Node middle = GetMiddle(head);
        Node nextOfMiddle = middle.Next;

        middle.Next = null;

        Node left = MergeSort(head);
        Node right = MergeSort(nextOfMiddle);

        return SortedMerge(left, right);
    }

    private Node GetMiddle(Node head)
    {
        if (head == null)
        {
            return head;
        }

        Node slow = head;
        Node fast = head.Next;

        while (fast != null)
        {
            fast = fast.Next;

            if (fast != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
        }

        return slow;
    }

    private Node SortedMerge(Node a, Node b)
    {
        Node result = null;

        if (a == null)
        {
            return b;
        }
        if (b == null)
        {
            return a;
        }

        if (a.Value.CompareTo(b.Value) <= 0)
        {
            result = a;
            result.Next = SortedMerge(a.Next, b);
        }
        else
        {
            result = b;
            result.Next = SortedMerge(a, b.Next);
        }

        return result;
    }

    public bool Empty()
    {
        return _count == 0;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }

    public T[] CopyToArray()
    {
        T[] array = new T[_count];
        Node current = _head;

        for(int i = 0; i < _count; ++i)
        {
            array[i] = current.Value;
            current = current.Next;
        }

        return array;
    }

    public static void CopyArray(T[] source, int sourceIndex, T[] destination, int destinationIndex, int length)
    {
        if (source == null || destination == null)
        {
            throw new ArgumentNullException("Source or Destination array is null.");
        }

        if (sourceIndex < 0 || destinationIndex < 0 || length < 0)
        {
            throw new ArgumentOutOfRangeException("SourceIndex, DestinationIndex, or Length is out of range.");
        }

        if (source.Length - sourceIndex < length || destination.Length - destinationIndex < length)
        {
            throw new ArgumentException("Source array or Destination array length is less than the number of elements to copy.");
        }

        for (int i = 0; i < length; i++)
        {
            destination[destinationIndex + i] = source[sourceIndex + i];
        }
    }
}

public class MyArrayTest
{
    public void Test()
    {
        MyArray<int> myArray = new MyArray<int>();
        myArray.Add(7);
        myArray.Add(2);
        myArray.Add(5);
        myArray.Add(1);
        myArray.Add(6);

        Console.WriteLine($"Array Count : {myArray.Count}");

        for(int i = 0; i < myArray.Count; ++ i)
        {
            Console.WriteLine(myArray[i]);
        }

        myArray.Sort();
        Console.WriteLine($"Array MergeSort...");

        for(int i = 0; i < myArray.Count; ++ i)
        {
            Console.WriteLine(myArray[i]);
        }
    }
}