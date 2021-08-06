using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddItemShouldThrowAnExceptionIfTheCellDoesNotExist()
        {
            var bankVault = new BankVault();
            var item = new Item("Pesho","1");
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("D4", item));
        }
        [Test]
        public void AddItemShouldThrowAnExceptionIfTheCellIsAlreadyTaken()
        {
            var bankVault = new BankVault();
            var item1 = new Item("Pesho", "1");
            var item2 = new Item("Toshko", "2");
            bankVault.AddItem("A1", item1);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item2));
        }

        [Test]
        public void AddItemShouldThrowAnExceptionIfTheItemIsAlreadyAdded()
        {
            var bankVault = new BankVault();
            var item1 = new Item("Pesho", "1");
            bankVault.AddItem("A1", item1);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item1));
        }
        [Test]
        public void AddItemShouldWorkAsExpected()
        {
            var bankVault = new BankVault();
            var item1 = new Item("Pesho", "1");
            bankVault.AddItem("A1", item1);
            Assert.AreEqual(bankVault.VaultCells["A1"], item1);
            Assert.AreEqual(bankVault.VaultCells["A1"].Owner, "Pesho");
            Assert.AreEqual(bankVault.VaultCells["A1"].ItemId, "1");

        }
        [Test]
        public void RemoveItemShouldThrowAnExceptionIfTheCellDoesNotExist()
        {
            var bankVault = new BankVault();
            var item = new Item("Pesho", "1");
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("D4", item));
        }

        [Test]
        public void RemoveItemShouldThrowAnExceptionIfTheItemDoesNotExist()
        {
            var bankVault = new BankVault();
            var item1 = new Item("Pesho", "1");
            var item2 = new Item("Toshko", "2");
            bankVault.AddItem("A1", item1);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item2));
        }

        [Test]
        public void RemoveItemShouldWorkAsExpected()
        {
            var bankVault = new BankVault();
            var item1 = new Item("Pesho", "1");
            var item2 = new Item("Toshko", "2");
            bankVault.AddItem("A1",item1);
            bankVault.AddItem("A2",item2);
            Assert.IsNotNull(bankVault.VaultCells["A1"]);
            Assert.IsNotNull(bankVault.VaultCells["A2"]);
            bankVault.RemoveItem("A1", item1);
            bankVault.RemoveItem("A2", item2);

            Assert.IsNull(bankVault.VaultCells["A1"]);
            Assert.IsNull(bankVault.VaultCells["A2"]);
        }
    }
}