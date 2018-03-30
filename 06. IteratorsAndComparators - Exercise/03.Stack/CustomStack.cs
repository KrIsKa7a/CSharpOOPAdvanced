using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    private List<T> data;

    public CustomStack()
    {
        this.data = new List<T>();
    }

    public CustomStack(ICollection<T> data)
    {
        this.data = new List<T>(data);
    }

    public void Push(params T[] elements)
    {
        this.data.AddRange(elements);
    }

    public T Pop()
    {
        if (this.data.Count <= 0)
        {
            throw new InvalidOperationException("No elements");
        }

        var poppedEl = this.data[this.data.Count - 1];
        this.data.RemoveAt(this.data.Count - 1);

        return poppedEl;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            yield return this.data[this.data.Count - 1 - i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
