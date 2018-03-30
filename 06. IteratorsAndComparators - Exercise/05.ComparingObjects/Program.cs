using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var persons = new List<Person>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var personArgs = input
                .Split();

            var name = personArgs[0];
            var age = int.Parse(personArgs[1]);
            var town = personArgs[2];

            var currentPerson = new Person(name, age, town);

            persons.Add(currentPerson);
        }

        var n = int.Parse(Console.ReadLine());

        var comparisonPerson = persons[n - 1];

        var equal = 0;
        var notequal = 0;

        foreach (var person in persons)
        {
            if (person.CompareTo(comparisonPerson) == 0)
            {
                equal++;
            }
            else
            {
                notequal++;
            }
        }

        if (equal <= 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equal} {notequal} {persons.Count}");
        }
    }
}
