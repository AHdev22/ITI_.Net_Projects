using System;
using System.Collections.Generic;

public class FixedSizeList<T>
{
    private T[] items;
    private int count;

    public FixedSizeList(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");
        items = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= items.Length)
            throw new InvalidOperationException("List is full.");
        items[count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException("Invalid index.");
        return items[index];
    }
}
