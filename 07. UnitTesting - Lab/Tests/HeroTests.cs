using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void TestIfHeroGainsXPWhenTargetDies()
        {
            var initializeHealth = 5;
            var initializeExperience = 10;

            var fakeWeapon = new Mock<IWeapon>();
            var fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(t => t.Health).Returns(initializeHealth);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(initializeExperience);

            var hero = new Hero("Prakash", fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(fakeTarget.Object.GiveExperience()));
        }
    }
}
