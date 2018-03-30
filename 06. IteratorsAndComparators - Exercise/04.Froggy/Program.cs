using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var stones = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var lake = new Lake(stones);

        Console.WriteLine(String.Join(", ", lake));
    }
}
