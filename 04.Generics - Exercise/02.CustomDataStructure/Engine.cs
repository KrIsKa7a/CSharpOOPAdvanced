using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private CustomList<string> customList;

    public Engine()
    {
        this.customList = new CustomList<string>();
    }

    public void Run()
    {
        while (true)
        {
            var cmdArgs = Console.ReadLine()
            .Split(' ');

            var cmdType = cmdArgs[0];

            if (cmdType == "END")
            {
                break;
            }

            try
            {
                TryParseCommand(cmdArgs, cmdType);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }

    private void TryParseCommand(string[] cmdArgs, string cmdType)
    {
        switch (cmdType)
        {
            case "Add":
                var element = cmdArgs[1];
                this.customList.Add(element);
                break;
            case "Remove":
                var index = int.Parse(cmdArgs[1]);
                this.customList.Remove(index);
                break;
            case "Contains":
                var elToContains = cmdArgs[1];
                Console.WriteLine(this.customList.Contains(elToContains));
                break;
            case "Swap":
                var index1 = int.Parse(cmdArgs[1]);
                var index2 = int.Parse(cmdArgs[2]);
                this.customList.Swap(index1, index2);
                break;
            case "Greater":
                var comparison = cmdArgs[1];
                Console.WriteLine(this.customList.CountGreaterThan(comparison));
                break;
            case "Max":
                Console.WriteLine(this.customList.Max());
                break;
            case "Min":
                Console.WriteLine(this.customList.Min());
                break;
            case "Print":
                Console.WriteLine(this.customList);
                break;
            case "Sort":
                this.customList.Sort();
                break;
            default:
                throw new ArgumentException("Invalid command type!");
        }
    }
}
