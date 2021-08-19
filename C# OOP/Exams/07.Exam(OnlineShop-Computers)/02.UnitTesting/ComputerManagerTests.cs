using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ItShouldInitializeEmptyList()
        {
            ComputerManager myComp = new ComputerManager();

            var computerList = 0;

            Assert.AreEqual(computerList, myComp.Computers.Count);
        }

        [Test]
        public void GetterCountShouldWorkAsExpected()
        {
            ComputerManager manager = new ComputerManager();
            var myCollection = new List<Computer>();

            Computer myComputer1 = new Computer("Apple", "GTX1", 1000);
            Computer myComputer2 = new Computer("Apple", "GTX2", 2000);
            Computer myComputer3 = new Computer("Apple", "GTX3", 3000);
            Computer myComputer4 = new Computer("Razer", "GTX4", 4000);
            Computer myComputer5 = new Computer("Azen", "GTX5", 5000);

            myCollection.Add(myComputer1);
            myCollection.Add(myComputer2);
            myCollection.Add(myComputer3);
            myCollection.Add(myComputer4);
            myCollection.Add(myComputer5);

            manager.AddComputer(myComputer1);
            manager.AddComputer(myComputer2);
            manager.AddComputer(myComputer3);
            manager.AddComputer(myComputer4);
            manager.AddComputer(myComputer5);

            Assert.AreEqual(myCollection.Count, manager.Count);
        }

        [Test]
        public void ItShouldThrowAnExceptionIfTheComputerExists()
        {
            ComputerManager manager = new ComputerManager();
            Computer myComputer = new Computer("Asus", "GTX", 1500);
            manager.AddComputer(myComputer);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(myComputer), "This computer already exists.");
        }
        [Test]
        public void ItShouldThrowAnExceptionIfComputerIsNull()
        {
            ComputerManager manager = new ComputerManager();
            Computer comp = null;

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(comp));
           
        }

        [Test]
        public void ItShouldWorkAsExpectedIfTheComputerDoesNotExist()
        {
            ComputerManager manager = new ComputerManager();
            Computer myComputer = new Computer("Asus", "GTX", 1500);
            var myListOfComputers = new List<Computer>();
            myListOfComputers.Add(myComputer);
            manager.AddComputer(myComputer);
            CollectionAssert.AreEqual(myListOfComputers, manager.Computers);
        }

        [Test]
        public void ItShouldRemoveComputerFromCollection()
        {
            ComputerManager manager = new ComputerManager();

            Computer myComputer1 = new Computer("Asus", "GTX", 1500);
            Computer myComputer2 = new Computer("Asus2", "GTX2", 1500);

            var myCollection = new List<Computer>();
            myCollection.Add(myComputer1);
            myCollection.Add(myComputer2);

            manager.AddComputer(myComputer1);
            manager.AddComputer(myComputer2);

            CollectionAssert.AreEqual(myCollection, manager.Computers);

            myCollection.Remove(myCollection.FirstOrDefault(x => x.Manufacturer == "Asus2" && x.Model == "GTX2"));
            manager.RemoveComputer("Asus2", "GTX2");

            CollectionAssert.AreEqual(myCollection, manager.Computers);

            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("Asus3", "GTX2"));
            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("Asus2", "GTX3"));
            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("Asus5", "GTX5"));
            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer(null, "GTX5"));
            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer("Asus5", null));
            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer(null, null));
        }
        

        [Test]
        public void ItShouldThrowAnExceptionIfTheComputerDoesNotExist()
        {
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(new Computer("Asus", "GTX", 2000));
            Assert.Throws<ArgumentException>(() => manager.GetComputer("Razer", "HTC"), "There is no computer with this manufacturer and model.");
        }
        [Test]
        public void ItShouldWorkAsExpectedWhenTheComputerExists()
        {
            ComputerManager manager = new ComputerManager();
            Computer myComputer = new Computer("Asus","GTX",2000);
            manager.AddComputer(myComputer);

            var computer = manager.GetComputer("Asus", "GTX");

            Assert.AreEqual(computer, myComputer);
            
        }

        [Test]
        public void ItShouldThrowAnExceptionIfManufacturerIsNull()
        {
            ComputerManager manager = new ComputerManager();
            Computer myComputer = new Computer("Asus", "GTX", 2000);
            manager.AddComputer(myComputer);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "GTX"), "Can not be null!");
        }

        [Test]
        public void ItShouldThrowAnExceptionIfModelIsNull()
        {
            ComputerManager manager = new ComputerManager();
            Computer myComputer = new Computer("Asus", "GTX", 2000);
            manager.AddComputer(myComputer);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("Asus", null), "Can not be null!");
        }

        [Test]
        public void GetComputersByManufacturerShouldWorkAsExepcted()
        {
            ComputerManager manager = new ComputerManager();

            Computer myComputer1 = new Computer("Apple", "GTX1", 1000);
            Computer myComputer2 = new Computer("Apple", "GTX2", 2000);
            Computer myComputer3 = new Computer("Apple", "GTX3", 3000);
            Computer myComputer4 = new Computer("Razer", "GTX4", 4000);
            Computer myComputer5 = new Computer("Azen", "GTX5", 5000);

            manager.AddComputer(myComputer1);
            manager.AddComputer(myComputer2);
            manager.AddComputer(myComputer3);
            manager.AddComputer(myComputer4);
            manager.AddComputer(myComputer5);

            var myCollection = new List<Computer>();
            myCollection.Add(myComputer1);
            myCollection.Add(myComputer2);
            myCollection.Add(myComputer3);

            CollectionAssert.AreEqual(myCollection, manager.GetComputersByManufacturer("Apple"));
        }

        [Test]
        public void GetComputersByManufacturerShouldThrowAnExceptionIfManufacturerIsNull()
        {
            ComputerManager manager = new ComputerManager();

            Computer myComputer1 = new Computer("Apple", "GTX1", 1000);
            Computer myComputer2 = new Computer("Apple", "GTX2", 2000);
            Computer myComputer3 = new Computer("Apple", "GTX3", 3000);
            Computer myComputer4 = new Computer("Razer", "GTX4", 4000);
            Computer myComputer5 = new Computer("Azen", "GTX5", 5000);

            manager.AddComputer(myComputer1);
            manager.AddComputer(myComputer2);
            manager.AddComputer(myComputer3);
            manager.AddComputer(myComputer4);
            manager.AddComputer(myComputer5);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null), "Can not be null!");
        }
    }
}