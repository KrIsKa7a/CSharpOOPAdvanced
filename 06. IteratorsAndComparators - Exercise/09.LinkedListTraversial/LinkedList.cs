using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node Next { get; set; }
    }

    public Node Head { get; private set; }

    public Node Tail { get; private set; }

    public int Count { get; private set; }

    public void Add(T value)
    {
        var old = this.Tail;
        this.Tail = new Node(value);

        if (isEmpty())
        {
            this.Head = this.Tail;
        }
        else
        {
            old.Next = this.Tail;
        }

        this.Count++;
    }

    public void Remove(T item)
    {
        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
            this.Count--;
        }

        if (this.Head.Value.Equals(item))
        {
            this.Head = this.Head.Next;
            this.Count--;
        }

        var currentNode = this.Head;

        for (int i = 0; i < this.Count - 1; i++)
        {
            var nextToCurrentNode = currentNode.Next;

            if (currentNode == null || nextToCurrentNode == null)
            {
                break;
            }

            if (nextToCurrentNode.Value.Equals(item))
            {
                currentNode.Next = nextToCurrentNode.Next;
                this.Count--;
                break;
            }

            currentNode = currentNode.Next;
        }

    }

    private bool isEmpty()
    {
        return this.Count == 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
