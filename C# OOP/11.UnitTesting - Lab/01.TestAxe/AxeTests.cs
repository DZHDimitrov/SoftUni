using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLoosesDurbailityAfterAttack()
    {
        //Arrange
        Axe axe = new Axe(100, 100);
        Dummy dummy = new Dummy(25, 50);
        //act
        axe.Attack(dummy);
        var expectedResult = 99;
        var actualResult = axe.DurabilityPoints;

        //assert
        Assert.AreEqual(expectedResult, actualResult);
    }
    [Test]
    public void AxeShouldNotAttackWithBrokenWeapon()
    {
        //Arrange
        Axe axe = new Axe(100, 0);
        Dummy dummy = new Dummy(100, 100);
        //Act
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}