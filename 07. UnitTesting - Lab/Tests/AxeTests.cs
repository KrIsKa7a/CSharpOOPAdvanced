using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void WeaponShouldLoooseDurabilityAfterAttack()
        {
            var initializeAttack = 5;
            var initializeDurability = 10;
            var initializeHealth = 5;
            var initializeExperience = 10;
            var expectedDurability = 9;

            var axe = new Axe(initializeAttack, initializeDurability);
            var target = new Dummy(initializeHealth, initializeExperience);

            axe.Attack(target);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurability));
        }

        [Test]
        public void TryAttackingWithBrokenWeapon()
        {
            var initializeAttack = 5;
            var initializeDurability = 0;
            var initializeHealth = 5;
            var initializeExperience = 10;

            var axe = new Axe(initializeAttack, initializeDurability);
            var target = new Dummy(initializeHealth, initializeExperience);

            Assert.That(() => axe.Attack(target), Throws.InvalidOperationException.With.Message.EqualTo(("Axe is broken.")));
        }
    }
}
