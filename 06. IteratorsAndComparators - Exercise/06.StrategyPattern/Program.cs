using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var nameset = new SortedSet<Person>(new NameComparator());
        var ageset = new SortedSet<Person>(new AgeComparator());

        for (int i = 0; i < n; i++)
        {
            var personArgs = Console.ReadLine()
                .Split();

            var name = personArgs[0];
            var age = int.Parse(personArgs[1]);

            var person = new Person(name, age);

            nameset.Add(person);
            ageset.Add(person);
        }

        Console.WriteLine(String.Join(Environment.NewLine, nameset));
        Console.WriteLine(String.Join(Environment.NewLine, ageset));
    }
}
