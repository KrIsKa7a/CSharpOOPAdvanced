using System;

class Program
{
    static void Main(string[] args)
    {
        var linkedList = new LinkedList<int>();

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var cmdArgs = Console.ReadLine()
                .Split();

            var cmdType = cmdArgs[0];
            var value = int.Parse(cmdArgs[1]);

            if (cmdType == "Add")
            {
                linkedList.Add(value);
            }
            else if (cmdType == "Remove")
            {
                linkedList.Remove(value);
            }
        }

        Console.WriteLine(linkedList.Count);
        Console.WriteLine(String.Join(" ", linkedList));
    }
}
