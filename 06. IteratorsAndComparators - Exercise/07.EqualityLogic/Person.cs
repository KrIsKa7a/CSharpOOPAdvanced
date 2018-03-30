using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }

    public int Age { get; }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj is Person otherPerson)
        {
            return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }
}
