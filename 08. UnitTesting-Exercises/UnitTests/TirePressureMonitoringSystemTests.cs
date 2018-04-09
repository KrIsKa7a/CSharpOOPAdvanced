using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace UnitTests
{
    [TestFixture]
    class TirePressureMonitoringSystemTests
    {
        [Test]
        [TestCase(19)]
        [TestCase(17)]
        [TestCase(20)]
        [TestCase(21)]
        public void TestSystemWithValidValues(double sensorValue)
        {
            var fakeSensor = new Mock<ISensor>();
            fakeSensor
                .Setup(fs => fs.PopNextPressurePsiValue())
                .Returns(sensorValue);

            var fakeSensorObj = fakeSensor.Object;

            var alarm = new Alarm(fakeSensor.Object);

            //Not Sucess as Mock.Object returns proxy type :(
            //typeof(Alarm)
            //    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            //    .First(f => f.FieldType == typeof(Sensor))
            //    .SetValue(alarm, fakeSensorObj);

            var expectedValue = false;

            alarm.Check();
            var actualValue = alarm.AlarmOn;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(10)]
        [TestCase(29)]
        [TestCase(16.9)]
        [TestCase(21.1)]
        public void TestSystemWithInvalidValues(double sensorValue)
        {
            var fakeSensor = new Mock<ISensor>();
            fakeSensor
                .Setup(fs => fs.PopNextPressurePsiValue())
                .Returns(sensorValue);

            var fakeSensorObj = fakeSensor.Object;

            var alarm = new Alarm(fakeSensor.Object);

            var expectedValue = true;

            alarm.Check();
            var actualValue = alarm.AlarmOn;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
