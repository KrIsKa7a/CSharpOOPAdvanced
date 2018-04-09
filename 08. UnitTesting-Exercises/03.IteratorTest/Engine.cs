using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private ListyIterator<string> listyIterator;

    public Engine()
    {
        
    }

    public void Run()
    {
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                ParseCommand(command);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private void ParseCommand(string command)
    {
        var cmdArgs = command
                        .Split();

        var cmdType = cmdArgs[0];

        switch (cmdType)
        {
            case "Create":
                var data = cmdArgs.Skip(1)
                    .ToArray();
                this.listyIterator = new ListyIterator<string>(data);
                break;
            case "Move":
                Console.WriteLine(this.listyIterator.Move());
                break;
            case "Print":
                this.listyIterator.Print();
                break;
            case "HasNext":
                Console.WriteLine(this.listyIterator.HasNext());
                break;
            case "PrintAll":
                Console.WriteLine(String.Join(" ", this.listyIterator));
                break;
        }
    }
}
