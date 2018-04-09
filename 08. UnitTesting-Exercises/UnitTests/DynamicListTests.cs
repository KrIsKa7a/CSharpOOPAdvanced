using _08.CustomLinkedList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    class DynamicListTests
    {
        private DynamicList<int> dl;

        [SetUp]
        public void TestInit()
        {
            this.dl = new DynamicList<int>();
        }

        [Test]
        public void TestIfCountWorkProperly()
        {
            var expectedCount = 0;
            var actualCount = this.dl.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-12312)]
        public void TestGettingIndexUnderZero(int index)
        {
            int val;

            Assert.Throws<ArgumentOutOfRangeException>(() => val = this.dl[index], "Index cannot be less than zero!");
        }

        [Test]
        [TestCase(10)]
        public void TestGettingIndexAboveListSize(int index)
        {
            int val;

            Assert.Throws<ArgumentOutOfRangeException>(() => val = this.dl[index], "Index must be in bounds of the List!");
        }

        [Test]
        public void TestGettingWithAValidIndex()
        {
            this.dl.Add(10);
            this.dl.Add(20);

            var expectedVal = 10;
            var actualVal = this.dl[0];

            Assert.That(actualVal, Is.EqualTo(expectedVal));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void TestSettingItemWithIndexUnderZero(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dl[index] = 10, "Index cannot be less than zero!");
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        public void TestSettingItemWithIndexBiggerThanListSize(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dl[index] = 10, "Index cannot be outside of the bounds of the list!");
        }

        [Test]
        public void TestSettingItemWithValidIndex()
        {
            var expectedValue = 10;

            this.dl.Add(5);

            this.dl[0] = expectedValue;
            var actualValue = this.dl[0];

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(10)]
        public void TestAddingAnItemToEmptyList(int item)
        {
            this.dl.Add(item);

            var expectedCount = 1;

            var actualCount = this.dl.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(100)]
        public void TestAddingAnItemToListWithElements(int count)
        {
            for (int i = 0; i < count; i++)
            {
                dl.Add(i);
            }

            int[] actualValues = GetActualValues(count);

            var expectedValues = Enumerable.Range(0, count);

            Assert.That(dl.Count, Is.EqualTo(count));
            Assert.That(actualValues, Is.EquivalentTo(expectedValues));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(100)]
        public void TestRemovingAtInvalidIndex(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dl.RemoveAt(index), "Index cannot be outside of the bounds of the array!");
        }

        [Test]
        public void TestRemovingAtValidIndex()
        {
            this.dl.Add(10);
            this.dl.Add(15);
            this.dl.Add(20);

            var indexToRemoveAt = 1;
            var expectedValue = 15;
            var actualValue = this.dl.RemoveAt(indexToRemoveAt);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TestValidRemove()
        {
            var valueToRemove = 15;

            dl.Add(10);
            dl.Add(valueToRemove);
            dl.Add(20);

            var expectedIndex = 1;
            var actualIndex = dl.Remove(valueToRemove);

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void TestInvalidRemove()
        {
            var valueToRemove = 30;

            dl.Add(10);
            dl.Add(15);
            dl.Add(20);

            var expectedIndex = -1;
            var actualIndex = dl.Remove(valueToRemove);

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void TestIndexOfWithExistingItem()
        {
            var valueToFind = 15;

            dl.Add(10);
            dl.Add(valueToFind);
            dl.Add(20);

            var expectedIndex = 1;
            var actualIndex = dl.IndexOf(valueToFind);

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void TestIndexOfWithInexistingItem()
        {
            var valueToFind = 30;

            dl.Add(10);
            dl.Add(15);
            dl.Add(20);

            var expectedIndex = -1;
            var actualIndex = dl.IndexOf(valueToFind);

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
        }
        
        [Test]
        public void TestValidContains()
        {
            var valueToFind = 15;

            dl.Add(10);
            dl.Add(valueToFind);
            dl.Add(20);

            var expectedValue = true;
            var actualValue = dl.Contains(valueToFind);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TestInvalidContains()
        {
            var valueToFind = 30;

            dl.Add(10);
            dl.Add(15);
            dl.Add(20);

            var expectedValue = false;
            var actualValue = dl.Contains(valueToFind);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        private int[] GetActualValues(int count)
        {
            var nums = new int[count];

            for (int i = 0; i < count; i++)
            {
                nums[i] = dl[i];
            }

            return nums;
        }
    }
}
