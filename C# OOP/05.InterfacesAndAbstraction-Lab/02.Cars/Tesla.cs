using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla : IElectricCar
    {
        public Tesla(string model,string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
