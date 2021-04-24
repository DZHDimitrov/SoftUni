using NUnit.Framework;
using System.Linq;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database dataBase = new Database(numbers);


            Assert.AreEqual(dataBase.Count, 16);
        }


        [Test]
        public void ConstructorShouldThrowAnExceptionIfSizeIsDifferentFrom16()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database dataBase = new Database(numbers);


            Assert.AreEqual(dataBase.Count, 16);
        }

        [Test]
        public void ShouldAddElementAtNextFreeCell()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database dataBase = new Database(numbers);
            dataBase.Add(5);

            var allElements = dataBase.Fetch();

            var expectedValue = 5;
            var actualValue = allElements[10];

            int expectedCount = 11;
            int actualCount = dataBase.Count;

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ShouldThrowExceptionIfThereAreMoreThan16Elements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database dataBase = new Database(numbers);


            Assert.Throws<InvalidOperationException>(() => dataBase.Add(3));

        }

        [Test]
        public void RemoveOperationShouldRemoveElementAtLastIndex()
        {
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database dataBase = new Database(numbers);

            dataBase.Remove();
            int expectedResult = 4;
            int actualResult = dataBase.Fetch()[3];

            int expectedCount = 4;
            int actualCount = dataBase.Count;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void EmptyDataBaseShouldThrowAnException()
        {
            Database dataBase = new Database();

            Assert.Throws<InvalidOperationException>(() => dataBase.Remove());
        }
        [Test]
        public void FetchShouldReturnElementsAsArray()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database dataBase = new Database(numbers);

            int[] expectedResult = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[] actualResult = dataBase.Fetch();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }


    }
}