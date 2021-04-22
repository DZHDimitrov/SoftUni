using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLoseHealthIfAttacked()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 50);

        //Act
        dummy.TakeAttack(20);
        var expectedResult = 80;
        var actualResult = dummy.Health;

        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 50);

        //Act
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(15));
    }
    [Test]
    public void DeadDummyShouldGiveXp()
    {
        //Arrange
        Dummy dummy = new Dummy(0,100);

        //Act
        int expectedResult = 100;
        int realResult = dummy.GiveExperience();

        //Assert
        Assert.AreEqual(expectedResult, realResult);
    }
    [Test]
    public void AliveDummyShouldNotGiveXp()
    {
        //Arrange
        Dummy dummy = new Dummy(50, 100);

        //Act
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
