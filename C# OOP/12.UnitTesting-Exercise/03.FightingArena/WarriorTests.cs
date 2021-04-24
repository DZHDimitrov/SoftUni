
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructorShouldThrowAnArgumentExceptionIfNameIsEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShouldThrowAnArgumentExceptionIfDamageIsZeroOrNegatve(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", damage, 100));
        }

        [Test]
        [TestCase(-1)]
        public void ConstructorShouldThrowAnArgumentExceptionIfHpIsNegative(int health)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", 150, health));
        }

        [Test]
        [TestCase(30,60)]
        [TestCase(29,30)]
        [TestCase(40,29)]
        [TestCase(45,30)]
        public void AttackMethodShouldThrowInvalidOperationException(int health,int enemyHealth)
        {
            warrior = new Warrior("Gogi", 20, health);
            Warrior enemyWarrior = new Warrior("Petio", 20, enemyHealth);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase(60)]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfHpIsLessThanEnemyDamage(int damage)
        {
            warrior = new Warrior("Pencho", 50, 50);
            Warrior enemyWarrior = new Warrior("Aragorn", damage, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase(50,20)]
        public void AttackMethodShouldDecreaseHp(int health,int result)
        {
            warrior = new Warrior("Warrior", 30, health);
            Warrior enemyWarrior = new Warrior("Enemy", 30, 55);

            warrior.Attack(enemyWarrior);
            int expectedResult = result;
            int actualResult = warrior.HP;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        [TestCase(50,40,0)]
        [TestCase(50,60,10)]
        [TestCase(50,62,12)]
        public void AttackMethodShouldSetEnemyHpToZeroIfOurDamageIsBiggerThanHisHp(int damage, int enemyHealth,int result)
        {
            warrior = new Warrior("Warrior", damage, 50);
            Warrior enemyWarrior = new Warrior("Enemy", 50, enemyHealth);

            warrior.Attack(enemyWarrior);
            int expectedResult = result;
            int actualResult = enemyWarrior.HP;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}