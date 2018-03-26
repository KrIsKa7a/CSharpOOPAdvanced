using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T content;

    public Box(T element)
    {
        this.content = element;
    }

    public T Content
    {
        get
        {
            return this.content;
        }
    }

    public override string ToString()
    {
        return $"{this.Content.GetType().FullName}: {this.Content.ToString()}";
    }
}
