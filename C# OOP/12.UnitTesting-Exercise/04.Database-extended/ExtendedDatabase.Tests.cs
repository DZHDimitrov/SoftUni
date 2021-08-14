using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendDb;

        [SetUp]
        public void Setup()
        {
            extendDb = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddInitialPeopleToTheDb()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Name:{i}");
            }
            extendDb = new ExtendedDatabase(persons);
            Assert.AreEqual(extendDb.Count, persons.Length);

            foreach (var person in persons)
            {
                Person dbPerson = extendDb.FindById(person.Id);
                Assert.AreEqual(person, dbPerson);
            }
        }
        [Test]
        public void Ctor_ThrowsExceptionWhenCapacityIsExceeded()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i,$"Pesho{i}");
            }
            Assert.Throws<ArgumentException>(() => extendDb = new ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ThrowsExceptionWhenCountIsExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                extendDb.Add(new Person(i, $"Name{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => extendDb.Add(new Person(16, "asd")));
        }
        [Test]
        public void Add_ThrowsExceptionWhenUsernameExists()
        {
            var name = "Pesho";
            extendDb.Add(new Person(1, name));
            Assert.Throws<InvalidOperationException>(() => extendDb.Add(new Person(16, name)));
        }

        [Test]
        public void Add_ThrowsExceptionWhenIdExists()
        {
            var id = 1;
            extendDb.Add(new Person(id, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => extendDb.Add(new Person(id, "Ivan")));
        }

        [Test]
        public void Add_IncrementCountWhenAllIsValid()
        {
            var expectedCount = 2;
            extendDb.Add(new Person(1, "Pesho"));
            extendDb.Add(new Person(2, "Gosho"));
            Assert.AreEqual(expectedCount, extendDb.Count);
        }

        [Test]
        public void Remove_ThrowsExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendDb.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDb()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendDb.Add(new Person(i, $"Name{i}"));
            }
            extendDb.Remove();
            Assert.AreEqual(extendDb.Count, n - 1);
            Assert.Throws<InvalidOperationException>(() => extendDb.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsExceptionWhenUsernameIsInvalid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendDb.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowsExceptionWhenUsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendDb.FindByUsername("Pesho"));
        }

        [Test]
        public void FindByUsername_ReturnsCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendDb.Add(person);
            Assert.AreEqual(person, extendDb.FindByUsername("Pesho"));
        }

        [Test]
        public void FindById_ThrowsExceptionWhenIdIsInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => extendDb.FindById(1));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-21)]
        public void FindById_ThrowsExceptionWhenIdIsNegativeValue(int idValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendDb.FindById(idValue));
        }
        [Test]
        public void FindById_ReturnsCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendDb.Add(person);
            Assert.AreEqual(person, extendDb.FindById(1));
        }
    }
}