
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorShouldInitializeDependantValues()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
        }
        [Test]
        public void EnrollMethodShouldThrowAnExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new Warrior("Dido", 10, 10);
            Arena arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void EnrollMethodShouldAddANewWarriorToTheArena()
        {
            Warrior warriorOne = new Warrior("Dido", 10, 10);
            Warrior warriorTwo = new Warrior("Kiko", 15, 12);
            Warrior warriorThree = new Warrior("Pesho", 16, 18);
            Arena arena = new Arena();

            arena.Enroll(warriorOne);
            arena.Enroll(warriorTwo);
            arena.Enroll(warriorThree);

            int expectedCount = 3;
            int actualCount = arena.Count;
            var isAny = arena.Warriors.Any(x => x.Name == "Dido");

            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsTrue(isAny);
        }
        [Test]
        public void FightMethodShouldThrowAnExceptionIfThereAreNoSuchFighters()
        {
            Warrior warriorOne = new Warrior("Dido", 10, 40);
            Warrior warriorTwo = new Warrior("Kiko", 15, 40);
            Warrior warriorThree = new Warrior("Pesho", 16, 40);
            Arena arena = new Arena();

            arena.Enroll(warriorOne);
            arena.Enroll(warriorTwo);
            arena.Enroll(warriorThree);
            Warrior warriorFour = new Warrior("Hristo", 25, 35);
            Warrior warriorFive = new Warrior("Ceko", 23, 35);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorOne.Name, warriorFour.Name));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorFour.Name, warriorTwo.Name));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorFour.Name, warriorFive.Name));
        }
        [Test]
        public void FightMethodShouldMakeWarriorsAtack()
        {
            Warrior warriorOne = new Warrior("Dido", 20, 75);
            Warrior warriorTwo = new Warrior("Pepo", 21, 55);

            Arena arena = new Arena();
            arena.Enroll(warriorOne);
            arena.Enroll(warriorTwo);

            arena.Fight(warriorOne.Name, warriorTwo.Name);
            int warriorOneHp = arena.Warriors.FirstOrDefault(x => x.Name == "Dido").HP;
            int warriorTwoHp = arena.Warriors.FirstOrDefault(x => x.Name == "Pepo").HP;

            Assert.AreEqual(warriorOneHp, 54);
            Assert.AreEqual(warriorTwoHp, 35);


        }
    }
}
