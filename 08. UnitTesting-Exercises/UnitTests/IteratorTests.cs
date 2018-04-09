using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    class IteratorTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void TestConstructor(int[] data)
        {
            var li = new ListyIterator<int>(data);

            var internalData = (List<int>)typeof(ListyIterator<int>)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == typeof(List<int>))
                .GetValue(li);
            var internalIndex = (int)typeof(ListyIterator<int>)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == typeof(int))
                .GetValue(li);

            var expectedValueOfIndex = 0;

            Assert.That(internalData, Is.EquivalentTo(data.ToList()));
            Assert.That(internalIndex, Is.EqualTo(expectedValueOfIndex));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void TestCurrentPropertyReturn(int[] data)
        {
            var li = new ListyIterator<int>(data);

            var internalIndex = (int)typeof(ListyIterator<int>)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == typeof(int))
                .GetValue(li);
            var currentValue = (int)typeof(ListyIterator<int>)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .First(p => p.PropertyType == typeof(int))
                .GetValue(li);

            var expectedValueOfIndex = 0;
            var expectedValueOfProperty = data[0];

            Assert.That(currentValue, Is.EqualTo(expectedValueOfProperty));
            Assert.That(internalIndex, Is.EqualTo(expectedValueOfIndex));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void TestValidMove(int[] data)
        {
            var li = new ListyIterator<int>(data);
            var expectedValue = true;

            bool canMove = li.Move();

            Assert.That(canMove, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(new int[] { 1 })]
        public void TestInvalidMove(int[] data)
        {

            var li = new ListyIterator<int>(data);
            var expectedValue = false;

            li.Move();
            bool canMove = li.Move();

            Assert.That(canMove, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void TestValidHasNextMethod(int[] data)
        {
            var li = new ListyIterator<int>(data);
            var expectedValue = true;

            bool hasNext = li.HasNext();

            Assert.That(hasNext, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(new int[] { 1, 2 })]
        public void TestInvalidHasNextMethod(int[] data)
        {
            var li = new ListyIterator<int>(data);
            var expectedValue = false;

            li.Move();
            bool hasNext = li.HasNext();

            Assert.That(hasNext, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void TestValidPrinting(int[] data)
        {
            var li = new ListyIterator<int>(data);

            var currentValue = (int)typeof(ListyIterator<int>)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .First(p => p.PropertyType == typeof(int))
                .GetValue(li);

            var expectedValueOfProperty = data[0];

            Assert.That(currentValue, Is.EqualTo(expectedValueOfProperty));
        }

        [Test]
        [TestCase(new int[] { })]
        public void TestInvalidPrinting(int[] data)
        {
            var li = new ListyIterator<int>(data);

            Assert.That(() => li.Print(), Throws.InvalidOperationException);
        }
    }
}
