using System;
using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("Gogicha");
            Snake snake = new Snake("Koko");
            Lizard lizard = new Lizard("Liolio");
            Gorilla gorilla = new Gorilla("Petio");

            List<Animal> list = new List<Animal>();
            list.Add(bear);
            list.Add(snake);
            list.Add(lizard);
            list.Add(gorilla);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}