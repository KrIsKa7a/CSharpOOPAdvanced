using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var setPeople = new SortedSet<Person>();
        var hashPeople = new HashSet<Person>();


        for (int i = 0; i < n; i++)
        {
            var inputArgs = Console.ReadLine()
                .Split();

            var name = inputArgs[0];
            var age = int.Parse(inputArgs[1]);

            var person = new Person(name, age);

            setPeople.Add(person);
            hashPeople.Add(person);
        }

        Console.WriteLine(setPeople.Count);
        Console.WriteLine(hashPeople.Count);
    }
}
