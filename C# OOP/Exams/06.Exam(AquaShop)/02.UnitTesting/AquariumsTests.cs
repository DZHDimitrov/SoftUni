namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public static void PropertyNameShouldThrowAnExeptionIfTheParameterIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() =>  new Aquarium(null, 5));
            Assert.Throws<ArgumentNullException>(() =>  new Aquarium("", 5));
        }
        [Test]
        public static void PropertyNameShouldWorkAsExpected()
        {
            Aquarium aquarium = new Aquarium("myAqua",5);
            Assert.AreEqual("myAqua", aquarium.Name);
        }
        [Test]
        public static void PropertyCapacityShouldThrowAnExceptionIfTheParameterIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("aqua", -5));
            Assert.Throws<ArgumentException>(() => new Aquarium("aqua", -1));
        }
        [Test]
        public static void PropertyCapacityShouldWorkAsExpected()
        {
            Aquarium aquarium = new Aquarium("myAqua",5);
            Assert.AreEqual(5, aquarium.Capacity);
        }


        [Test]
        public static void AddMethodShouldThrowAnExceptionIfThereIsNoCapacity()
        {
            var aquarium = new Aquarium("aqua",1);
            Fish myFish1 = new Fish("Salmon");
            Fish myFish2 = new Fish("Tuna");
            aquarium.Add(myFish1);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(myFish2));
        }
        [Test]
        public static void AddMethodShouldWorkAsExpected()
        {
            var aquarium = new Aquarium("aqua",1);
            Fish myFish1 = new Fish("Salmon");
            aquarium.Add(myFish1);
            var myList = new List<Fish>();
            myList.Add(myFish1);
            Assert.AreEqual(myList.Count, aquarium.Count);
        }
        [Test]
        public static void RemoveMethodShouldThrowAnExceptionIfThereIsNoSuchFish()
        {
            var aquarium = new Aquarium("aqua",5);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Salmon"));
        }

        [Test]
        public static void RemoveMethodShouldWorkAsExpected()
        {
            var aquarium = new Aquarium("aqua", 5);
            var fish1 = new Fish("salmon");
            var fish2 = new Fish("tuna");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.AreEqual(2, aquarium.Count);
            aquarium.RemoveFish("salmon");
            Assert.AreEqual(1, aquarium.Count);
            aquarium.RemoveFish("tuna");
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public static void SellFishMethodShouldThrowAnExceptionIfTheFishDoesNotExist()
        {
            var aquarium = new Aquarium("aqua", 5);
            var fish1 = new Fish("salmon");
            var fish2 = new Fish("tuna");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("somefish"));
        }
        [Test]
        public static void SellFishMethodShouldWorkAsExpected()
        {
            var aquarium = new Aquarium("aqua", 5);
            var fish1 = new Fish("salmon");
            var fish2 = new Fish("tuna");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            var myFish = fish1;
            Assert.AreEqual(myFish, aquarium.SellFish("salmon"));
            Assert.AreEqual(myFish.Available = false, aquarium.SellFish("salmon").Available);
        }
        [Test]
        public static void ReportMethodShouldWorkAsExpected()
        {
            var aquarium = new Aquarium("aqua", 5);
            var fish1 = new Fish("salmon");
            var fish2 = new Fish("tuna");
            var fish3 = new Fish("shark");
            var myList = new List<Fish>();
            myList.Add(fish1);
            myList.Add(fish2);
            myList.Add(fish3);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            var result = $"Fish available at {aquarium.Name}: {string.Join(", ",myList.Select(x => x.Name))}";
            Assert.AreEqual(result, aquarium.Report());
        }
    }
}
