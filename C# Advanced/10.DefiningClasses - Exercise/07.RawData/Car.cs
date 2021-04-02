using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public Cargo Cargo { get; set; }


        public Car(string model, Engine engine, Tire[] tires, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Tires = tires;
            Cargo = cargo;
        }
    }
}
