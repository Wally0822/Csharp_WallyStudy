namespace Csharp_WallyStudy.DataStructure;

public class MyList<T> where T : IComparable<T>
{
    private T[] _items;
    private int _count;

    public MyList()
    {
        _items = Array.Empty<T>();
        _count = 0;
    }

    public int Count => _count;

    public T this[int index]
    {
        get
        {
            if(index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[index];
        }
        set
        {
            if(index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _items[index] = value;
        }
    }

    private void Grow()
    {
        T[] newItems = new T[_count + 1];
        MyArray<T>.CopyArray(_items, 0, newItems, 0, _count);
        _items = newItems;
    }

    public void Add(T item)
    {
        Grow();

        _items[_count] = item;
        _count++;
    }

    public void Insert(int index, T item)
    {
        if(index < 0 || index > _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Grow();

        for(int i = _count; i > index; i --)
        {
            _items[i] = _items[i - 1];
        }

        _items[index] = item;
        _count++;
    }

    public void RemoveAt(int index)
    {
        if(index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        _count--;

        for(int i = index; i <_count; i++)
        {
            _items[i] = _items[i + 1];
        }

        T[] newItems = new T[_count];
        MyArray<T>.CopyArray(_items, 0, newItems, 0, _count);
        _items = newItems;
    }

    public bool Contains(T item)
    {
        for(int i = 0; i < _count; ++i)
        {
            if (_items[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public int IndexOf(T item) 
    {
        for(int i = 0; i < _count; i ++)
        {
            if (_items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Clear()
    {
        _items = Array.Empty<T>();
        _count = 0;
    }
}

public class MyListDemo
{
    public void Run()
    {
        MyList<int> list = new MyList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Console.WriteLine($"List count : {list.Count}");

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        list.RemoveAt(1);
        Console.WriteLine("After removing element at index : 1");

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        list.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        Console.WriteLine($"List count after clearing : {list.Count}");
    }
}