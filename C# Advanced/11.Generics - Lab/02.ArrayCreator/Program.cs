using System;

namespace GenericArrayCreator
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            var array = ArrayCreator.Create(10, 1.5);
            Console.WriteLine(string.Join(" ", array));
            
        }
    }
}
