using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Database
{
    public class ExtendedDatabase
    {
        private List<Person> persons;
        private int currentIndex;

        private ExtendedDatabase()
        {
            this.persons = new List<Person>();
            this.currentIndex = 0;
        }

        public ExtendedDatabase(params Person[] initialValues)
            : this()
        {
            SetValues(initialValues);
        }

        public void Add(Person person)
        {
            if (this.persons.Any(p => p.Id == person.Id || p.UserName == person.UserName))
            {
                throw new InvalidOperationException("Already existing Id or Username!");
            }
            this.currentIndex++;
            this.persons.Add(person);
        }

        public Person Remove()
        {
            if (this.persons.Count == 0)
            {
                throw new InvalidOperationException("There are no persons in Database!");
            }

            this.currentIndex--;

            var elementToRemove = this.persons[this.persons.Count - 1];

            this.persons.RemoveAt(this.persons.Count - 1);

            return elementToRemove;
        }

        public Person FindByUsername(string username = null)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null!");
            }

            if (!this.persons.Any(p => p.UserName == username))
            {
                throw new InvalidOperationException("Invalid username!");
            }

            var wantedPerson = this.persons
                .First(p => p.UserName == username);

            return wantedPerson;
        }

        public Person FindById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be null or negative!");
            }

            if (!this.persons.Any(p => p.Id == id))
            {
                throw new InvalidOperationException("Invalid id!");
            }

            var wantedPerson = this.persons
                .First(p => p.Id == id);

            return wantedPerson;
        }

        private void SetValues(Person[] initialValues)
        {
            for (int i = 0; i < initialValues.Length; i++)
            {
                this.persons.Add(initialValues[i]);
                this.currentIndex++;
            }
        }
    }
}
