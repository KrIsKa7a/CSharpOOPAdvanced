using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLooseHealthIfAttacked()
        {
            var initializeHealth = 10;
            var initializeExperience = 5;
            var damageAmount = 5;
            var expectedHealth = 5;

            var dummy = new Dummy(initializeHealth, initializeExperience);

            dummy.TakeAttack(damageAmount);

            Assert.That(dummy.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            var initializeHealth = 0;
            var initializeExperience = 10;
            var damageAmount = 5;
            var expectedExceptionMessage = "Dummy is dead.";

            var dummy = new Dummy(initializeHealth, initializeExperience);

            Assert.That(() => dummy.TakeAttack(damageAmount),
                Throws.InvalidOperationException.With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void DeadDummyShouldBeAbleToGiveXP()
        {
            var initializeHealth = 0;
            var initializeExperience = 10;

            var dummy = new Dummy(initializeHealth, initializeExperience);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(initializeExperience));
        }

        [Test]
        public void AliveDummyShouldntBeAbleToGiveXP()
        {
            var initializeHealth = 5;
            var initializeExperience = 10;
            var expectedExceptionMessage = "Target is not dead.";

            var dummy = new Dummy(initializeHealth, initializeExperience);

            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo(expectedExceptionMessage));
        }
    }
}
