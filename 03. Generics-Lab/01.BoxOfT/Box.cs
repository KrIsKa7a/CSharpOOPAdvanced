using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private Stack<T> data;

    public Box()
    {
        this.data = new Stack<T>();
    }

    public int Count => this.data.Count;

    public void Add(T element)
    {
        this.data.Push(element);
    }

    public T Remove()
    {
        var removedEl = this.data.Pop();

        return removedEl;
    }
}
