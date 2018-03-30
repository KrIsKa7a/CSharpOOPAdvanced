using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private const string InvalidOperationMessage = "Invalid Operation!";

    private List<T> data;
    private int internalIndex;

    public ListyIterator(params T[] data)
    {
        this.data = data.ToList();
        this.internalIndex = 0;
    }

    public T Current => this.data[internalIndex];

    public bool Move()
    {
        if (this.internalIndex + 1 < this.data.Count)
        {
            this.internalIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        return this.internalIndex + 1 < this.data.Count;
    }

    public void Print()
    {
        if (this.data.Count <= 0)
        {
            throw new InvalidOperationException(InvalidOperationMessage);
        }

        Console.WriteLine(this.Current);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
