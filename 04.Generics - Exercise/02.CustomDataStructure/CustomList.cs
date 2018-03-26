using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : List<T>, IEnumerable<T> where T : IComparable<T>
{
    private List<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }

    public new void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        var el = this.data[index];

        this.data.RemoveAt(index);

        return el;
    }

    public new bool Contains(T element)
    {
        return this.data.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var elindex1 = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = elindex1;
    }

    public int CountGreaterThan(T element)
    {
        var counter = 0;

        foreach (var el in this.data)
        {
            if (el.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public new int Count => this.data.Count;

    public new void Sort()
    {
        this.data = Sorter.Sort<T>(this.data);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var el in this.data)
        {
            sb.AppendLine(el.ToString());
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }
}
