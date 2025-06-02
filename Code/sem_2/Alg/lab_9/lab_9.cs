using System;

class Vector<T>
{
    int Capacity { get; set; }
    int Count { get; set; }
    const int Default_capacity = 4;
    T[] arr;

    public Vector()
    {
        arr = new T[Default_capacity];
        Capacity = Default_capacity;
    }

    public Vector(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException();

        arr = new T[capacity];
        Capacity = capacity;
    }

    public void Add(T item)
    {
        if (Count >= Capacity)
        {
            Resize();
        }

        arr[Count] = item;
        Count++;
    }

    private void Resize()
    {
        int new_capacity = Capacity * 2;
        T[] new_array = new T[new_capacity];

        for (int i = 0; i < Capacity; i++)
        {
            new_array[i] = arr[i];
        }

        Capacity = new_capacity;
        arr = new_array;
    }

    public T Get_at(int id)
    {
        if (id < 0 || id >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return arr[id];
    }

    public void Delete(int id)
    {
        if (id < 0 || id >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = id; i < Count - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        arr[Count - 1] = default;
        Count--;
    }
}