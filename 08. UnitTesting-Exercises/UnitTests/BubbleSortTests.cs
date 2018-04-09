using _04.BubbleSort;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    class BubbleSortTests
    {
        [Test]
        [TestCase(new int[] { 1, 5, 3, 2, 19, 10})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6})]
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2})]
        public void TestBubbleSort(int[] numbers)
        {
            var sortedActually = Bubble.Sort(numbers);
            Array.Sort(numbers);

            Assert.That(sortedActually, Is.EqualTo(numbers));
        }
    }
}
