using _09.DateTimes;
using Moq;
using NUnit.Framework;
using System;
using System.Globalization;

namespace UnitTests
{
    [TestFixture]
    class DateTimeTests
    {
        private Mock<IDateTime> fakeDateTime;

        [SetUp]
        public void Initialize()
        {
            this.fakeDateTime = new Mock<IDateTime>();
        }

        [Test]
        public void TestAddingDayToMiddleOfMonth()
        {
            var middleOfMonth = DateTime.ParseExact(
                "15.04.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expectedDate = DateTime.ParseExact(
                "16.04.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(middleOfMonth);

            var actualDate = fakeDateTime.Object.Now.AddDays(1);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestAddingADayToTheLastDayOfMonth()
        {
            var lastDayOfMonth = DateTime.ParseExact(
                "30.04.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expectedDate = DateTime.ParseExact(
                "01.05.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(lastDayOfMonth);

            var actualDate = fakeDateTime.Object.Now.AddDays(1);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestAddingANegativeDaysCount()
        {
            var middleOfMonth = DateTime.ParseExact(
                "15.04.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expectedDate = DateTime.ParseExact(
                "10.04.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(middleOfMonth);

            var actualDate = fakeDateTime.Object.Now.AddDays(-5);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestGoingToPreviousMonthUsingNegativeDaysCount()
        {
            var earlyOfMonth = DateTime.ParseExact(
                "04.04.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expectedDate = DateTime.ParseExact(
                "31.03.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(earlyOfMonth);

            var actualDate = fakeDateTime.Object.Now.AddDays(-4);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestAddingAddittionDayInLeapYear()
        {
            var endOfFeb = DateTime.ParseExact(
                "28.02.2012", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expectedDate = DateTime.ParseExact(
                "29.02.2012", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(endOfFeb);

            var actualDate = fakeDateTime.Object.Now.AddDays(1);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestGoindToMarchInLeapYear()
        {
            var endOfFeb = DateTime.ParseExact(
               "28.02.2012", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expectedDate = DateTime.ParseExact(
                "01.03.2012", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(endOfFeb);

            var actualDate = fakeDateTime.Object.Now.AddDays(2);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestGoingToMarchInNonLeapYears()
        {
            var endOfFeb = DateTime.ParseExact(
              "28.02.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expectedDate = DateTime.ParseExact(
                "01.03.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(endOfFeb);

            var actualDate = fakeDateTime.Object.Now.AddDays(1);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestAddingADayToDateTimeMin()
        {
            var dateTimeMin = DateTime.MinValue;
            var expectedDate = DateTime.MinValue.AddDays(1);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(dateTimeMin);

            var actualDate = fakeDateTime.Object.Now.AddDays(1);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void TestAddingADayToDateTimeMax()
        {
            var dateTimeMax = DateTime.MaxValue;
            var expectedDate = DateTime.MaxValue.AddDays(1);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(dateTimeMax);

            var actualDate = fakeDateTime.Object.Now.AddDays(1);

            Assert.That(actualDate, Is.EqualTo(expectedDate), "You are going out of range of supported times!");
        }

        [Test]
        public void TestSubtractingADayFromDateTimeMin()
        {
            var dateTimeMin = DateTime.MinValue;
            var expectedDate = DateTime.MinValue.AddDays(-1);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(dateTimeMin);

            var actualDate = fakeDateTime.Object.Now.AddDays(-1);

            Assert.That(actualDate, Is.EqualTo(expectedDate), "You are going out of range of supported times!");
        }

        [Test]
        public void TestSubtractingADayFromDateTimeMax()
        {
            var dateTimeMax = DateTime.MaxValue;
            var expectedDate = DateTime.MaxValue.AddDays(-1);

            fakeDateTime
                .Setup(dt => dt.Now)
                .Returns(dateTimeMax);

            var actualDate = fakeDateTime.Object.Now.AddDays(-1);

            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }
    }
}
