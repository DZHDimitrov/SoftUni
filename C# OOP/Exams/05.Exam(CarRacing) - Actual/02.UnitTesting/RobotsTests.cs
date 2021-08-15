namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class RobotsTests
    {
        private RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            this.robotManager = new RobotManager(10);
        }

        [Test]
        public void Capacity_ThrowsAnExceptionIfValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }
        [Test]
        public void Capacity_SetsCapacityWhenValueIsValid()
        {
            Assert.AreEqual(10, this.robotManager.Capacity);
        }
        [Test]
        public void Count_ReturnsCountOfRobots()
        {
            this.robotManager.Add(new Robot("Pesho", 10));
            this.robotManager.Add(new Robot("Jivko", 5));
            Assert.AreEqual(this.robotManager.Count, 2);
        }

        [Test]
        public void Add_ThrowsAnExceptionWhenTheNameAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>(() => 
            {
                this.robotManager.Add(new Robot("Pesho", 10));
                this.robotManager.Add(new Robot("Pesho", 5));
            });
        }
        [Test]
        public void Add_ThrowsAnExceptionWhenThereIsNoCapacity()
        {
            var myManager = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                myManager.Add(new Robot("Pesho", 15));
                myManager.Add(new Robot("Pesho1", 15));
            });
            Assert.Throws<InvalidOperationException>(() => 
            {
                for (int i = 0; i < 11; i++)
                {
                    this.robotManager.Add(new Robot($"Pesho{i}", i));
                }
            });
        }

        [Test]
        public void Add_AddsRobotWhenIsValid()
        {
            var robot = new Robot("Pesho", 5);
            this.robotManager.Add(robot);
            var myRobots = new List<Robot>();
            myRobots.Add(robot);
            Assert.AreEqual(myRobots.Count, this.robotManager.Count);
        }

        [Test]
        public void Remove_ThrowsAnExceptionIfTheRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("Pesho"));
        }
        [Test]
        public void Remove_RemovesTheRobotWhenTheRobotExists()
        {
            var robot = new Robot("Pesho", 5);
            this.robotManager.Add(robot);
            Assert.AreEqual(this.robotManager.Count, 1);
            this.robotManager.Remove("Pesho");
            Assert.AreEqual(this.robotManager.Count, 0);
        }
        [Test]
        public void Work_ThrowsAnExceptionIfTheRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("Pesho"));
        }
        [Test]
        public void Work_ThrowsAnExceptionIfTheRobotDoesNotHaveEnoughEnergyToWork()
        {
            var robot = new Robot("Pesho",15);
            robot.Battery = 5;
            this.robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Pesho", "waiter", 10));
        }
        [Test]
        public void Work_SubtractsBatterFromRobotWhenBatterIsEnoughToWork()
        {
            var robot = new Robot("Pesho", 15);
            robot.Battery = 15;
            this.robotManager.Add(robot);
            this.robotManager.Work("Pesho", "waiter", 10);
            Assert.AreEqual(5, robot.Battery);
        }

        [Test]
        public void Charge_ThrowsAnExceptionWhenTheRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("Pesho"));
        }

        [Test]
        public void Charge_RechargesRobotToFullBatterWhenRobotExists()
        {
            var robot = new Robot("Pesho", 25);
            robot.Battery = 10;
            this.robotManager.Add(robot);
            this.robotManager.Charge("Pesho");
            Assert.AreEqual(25, robot.Battery);
        }
    }
}
