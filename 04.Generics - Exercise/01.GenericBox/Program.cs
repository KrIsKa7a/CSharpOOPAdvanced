using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var boxes = new List<Box<double>>();

        for (int i = 0; i < n; i++)
        {
            var contentToBeBoxed = double.Parse(Console.ReadLine());

            var box = new Box<double>(contentToBeBoxed);

            boxes.Add(box);
        }

        var comparison = double.Parse(Console.ReadLine());

        var count = Count(boxes, comparison);

        Console.WriteLine(count);
    }

    static void Swap<T>(List<Box<T>> boxes, int index1, int index2)
    {
        var firstBox = boxes[index1];
        boxes[index1] = boxes[index2];
        boxes[index2] = firstBox;
    }

    static int Count<T>(List<Box<T>> boxes, T comparison) where T : IComparable<T>
    {
        int counter = 0;

        foreach (var box in boxes)
        {
            if (box.Content.CompareTo(comparison) > 0)
            {
                counter++;
            }
        }

        return counter;
    }
}
