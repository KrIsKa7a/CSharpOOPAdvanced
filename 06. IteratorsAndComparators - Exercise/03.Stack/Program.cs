using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string command;

        var stack = new CustomStack<int>();

        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                ParseCommand(command, stack);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        PrintElements(stack);
        PrintElements(stack);
    }

    private static void PrintElements(CustomStack<int> stack)
    {
        foreach (var el in stack)
        {
            Console.WriteLine(el);
        }
    }

    private static void ParseCommand(string command, CustomStack<int> stack)
    {
        var cmdArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var cmdType = cmdArgs[0];

        switch (cmdType)
        {
            case "Push":
                var elements = cmdArgs
                    .Skip(1)
                    .Select(el => int.Parse(el
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)[0]))
                    .ToArray();
                stack.Push(elements);
                break;
            case "Pop":
                stack.Pop();
                break;
        }
    }
}
