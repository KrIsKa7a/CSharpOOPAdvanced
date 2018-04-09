using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace UnitTests
{
    [TestFixture]
    class MathTests
    {
        [Test]
        [TestCase(10)]
        [TestCase(-10)]
        [TestCase(0)]
        public void TestMathAbsMethod(int value)
        {
            var expectedValue = value < 0 ? value * -1 : value;
            var actualValue = Math.Abs(value);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(2.3)]
        [TestCase(2.5)]
        [TestCase(2.7)]
        [TestCase(3.0)]
        public void TestMathFloorMethod(double value)
        {
            var expectedValue = Math.Truncate(value);

            var actualValue = Math.Floor(value);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
