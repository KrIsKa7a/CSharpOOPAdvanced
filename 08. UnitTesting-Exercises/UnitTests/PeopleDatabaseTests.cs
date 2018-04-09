using _01.Database;
using System.Reflection;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System;

namespace UnitTests
{
    [TestFixture]
    class PeopleDatabaseTests
    {
        [Test]
        public void TestValidConstructor()
        {
            var values = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho")
            };
            var db = new ExtendedDatabase(values);

            var innerIndex = (int)typeof(ExtendedDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(int))
                .GetValue(db);
            var innerValuesObject = (List<Person>)(typeof(ExtendedDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(List<Person>))
                .GetValue(db));
            var innerValues = innerValuesObject.Take(innerIndex);

            Assert.That(innerValues, Is.EquivalentTo(values));
            Assert.That(values.Length, Is.EqualTo(innerIndex));
        }

        [Test]
        public void TestValidAdd()
        {
            var initialValues = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho")
            };

            var db = new ExtendedDatabase(initialValues);

            var toAdd = new Person(3, "Misho");

            db.Add(toAdd);

            var innerIndex = (int)typeof(ExtendedDatabase)
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .FirstOrDefault(f => f.FieldType == typeof(int))
               .GetValue(db);

            Assert.That(innerIndex, Is.EqualTo(initialValues.Length + 1));
        }

        [Test]
        public void TestAddingExistingPersonId()
        {
            var initialValues = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho")
            };

            var db = new ExtendedDatabase(initialValues);

            //Same id
            var personConflictToAdd = new Person(1, "Stamat");

            Assert.That(() => db.Add(personConflictToAdd), Throws.InvalidOperationException);
        }

        [Test]
        public void TestAddingExistingPersonUsername()
        {
            var initialValues = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho")
            };

            var db = new ExtendedDatabase(initialValues);

            //Same username
            var personConflictToAdd = new Person(5, "Pesho");

            Assert.That(() => db.Add(personConflictToAdd), Throws.InvalidOperationException);
        }

        [Test]
        public void TestValidRemove()
        {
            var values = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho")
            };

            var db = new ExtendedDatabase(values);

            var valuesLastElement = values[values.Length - 1];
            var removedElement = db.Remove();

            var innerIndex = (int)typeof(ExtendedDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(int))
                .GetValue(db);
            var innerValues = (List<Person>)typeof(ExtendedDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(List<Person>))
                .GetValue(db);

            Assert.That(valuesLastElement, Is.EqualTo(removedElement));
            Assert.That(innerValues.Count, Is.EqualTo(values.Length - 1));
            Assert.That(innerIndex, Is.EqualTo(values.Length - 1));
        }

        [Test]
        public void TestInvalidRemove()
        {
            var db = new ExtendedDatabase();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("Pesho")]
        [TestCase("Gosho")]
        public void TestValidFindingByUsername(string username)
        {
            var values = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho")
            };

            var db = new ExtendedDatabase(values);

            var personFound = db.FindByUsername(username);
            var expectedPerson = values.First(p => p.UserName == username);

            Assert.That(personFound, Is.EqualTo(expectedPerson));
        }

        [Test]
        [TestCase(null)]
        public void TestFindingByNullUsername(string username)
        {
            var values = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho")
            };

            var db = new ExtendedDatabase(values);

            Assert.That(() => db.FindByUsername(username), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("Stamat")]
        public void TestFindingByInexistingUsername(string username)
        {
            var values = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho")
            };

            var db = new ExtendedDatabase(values);

            Assert.That(() => db.FindByUsername(username), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(2123123123L)]
        public void TestValidFindingById(long id)
        {
            var values = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2123123123, "Gosho")
            };

            var db = new ExtendedDatabase(values);

            var personFound = db.FindById(id);
            var expectedPerson = values.First(p => p.Id == id);

            Assert.That(personFound, Is.EqualTo(expectedPerson));
        }

        [Test]
        [TestCase(-10)]
        public void TestFindingByInvalidId(long id)
        {
            var values = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2123123123, "Gosho")
            };

            var db = new ExtendedDatabase(values);

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(id));
        }

        [Test]
        [TestCase(10)]
        public void TestFindingByInexistingId(long id)
        {
            var values = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2123123123, "Gosho")
            };

            var db = new ExtendedDatabase(values);

            Assert.Throws<InvalidOperationException>(() => db.FindById(id));
        }
    }
}
