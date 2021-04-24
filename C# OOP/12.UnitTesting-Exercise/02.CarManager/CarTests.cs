
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("VW", "Golf", 6.5, 40)]
        public void ConstructorShouldSetPropertiesCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("", "Golf", 6.5, 40)]
        [TestCase(null, "Golf", 6.5, 40)]
        public void ConstructorShouldThrowArgumentExceptionIfMakeIsNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase("VW", "", 6.5, 40)]
        [TestCase("VW", null, 6.5, 40)]
        public void ConstructorShouldThrowArgumentExceptionIfModelIsNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase("VW", "Golf", 0, 40)]
        [TestCase("VW", "Golf", -1, 40)]
        public void ConstructorShouldThrowArgumentExceptionIfFuelConsumptionIsNegativeOrZero(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase("VW", "Golf", 10, 0)]
        [TestCase("VW", "Golf", 10, -1)]
        public void ConstructorShouldThrowArgumentExceptionIfFuelIsNegativeOrZero(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase("VW", "Golf", 10, 40,0)]
        [TestCase("VW", "Golf", 10, 50,-1)]
        public void ReuelMethodShouldThrowAnArgumentExceptionIfItIsZeroOrNegative(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [TestCase("VW", "Golf", 10, 40, 10,20)]
        [TestCase("VW", "Golf", 10, 40, 35,40)]
        public void RefuelMethodShouldIncreaseFuelAmount(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel,double result)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelAmount, result);
        }

        [TestCase("VW", "Golf", 10, 40,20,201)]
        public void DriveMethodShouldThrowInvalidOperationExceptionIfItIsNotEnough(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double distance)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
        [TestCase("VW", "Golf", 10, 40, 35, 100)]
        public void DriveMethodShouldDecreaseFuelAmount(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double distance)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);
            car.Drive(distance);
            double expectedResult = 25;
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}