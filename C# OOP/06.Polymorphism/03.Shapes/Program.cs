using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shapeOne = new Rectangle(10, 5);
            Shape shapeTwo = new Circle(10);
            Console.WriteLine(shapeOne.CalculateArea());
            Console.WriteLine(shapeOne.CalculatePerimeter());
            shapeOne.Draw();
            Console.WriteLine(shapeTwo.CalculateArea());
            Console.WriteLine(shapeTwo.CalculatePerimeter());
            shapeTwo.Draw();


        }
    }
}
