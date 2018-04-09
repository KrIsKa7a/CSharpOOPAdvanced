using _01.Database;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        [TestCase(new int[] { })]
        public void TestValidConstructor(int[] values)
        {
            var db = new Database(values);

            var innerIndex = (int)typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(int))
                .GetValue(db);
            var innerValuesObject = (int[])(typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(int[]))
                .GetValue(db));
            var innerValues = innerValuesObject.Take(innerIndex);

            Assert.That(innerValues, Is.EquivalentTo(values));
            Assert.That(values.Length, Is.EqualTo(innerIndex));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void TestInvalidConstructor(int[] values)
        {
            Database db = null;

            Assert.That(() => db = new Database(values), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void TestValidAdd(int[] values)
        {
            var db = new Database(values);

            db.Add(16);

            var innerIndex = (int)typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(int))
                .GetValue(db);

            Assert.That(innerIndex, Is.EqualTo(values.Length + 1));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestInvalidAdd(int[] values)
        {
            var db = new Database(values);

            Assert.That(() => db.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestValidRemove(int[] values)
        {
            var db = new Database(values);

            var valuesLastElement = values[values.Length - 1];
            var removedElement = db.Remove();

            var innerIndex = (int)typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(int))
                .GetValue(db);
            var innerValues = ((int[])typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(int[]))
                .GetValue(db))
                .Take(innerIndex)
                .ToArray();

            Assert.That(valuesLastElement, Is.EqualTo(removedElement));
            Assert.That(innerValues.Length, Is.EqualTo(values.Length - 1));
            Assert.That(innerIndex, Is.EqualTo(values.Length - 1));
        }

        [Test]
        public void TestInvalidRemove()
        {
            var db = new Database();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 1, 2, 3, 4, 0 })]
        public void TestFetch(int[] values)
        {
            var db = new Database(values);

            var fetchedValues = db.Fetch();

            Assert.That(fetchedValues, Is.EquivalentTo(values));
        }
    }
}
