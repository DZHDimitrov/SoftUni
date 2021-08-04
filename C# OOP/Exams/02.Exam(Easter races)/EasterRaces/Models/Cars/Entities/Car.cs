using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private readonly int minHorsePower;
        private readonly int maxHorsePower;

        public Car(string model, int horsePower,double cubicCm,int minHorsePower,int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCm;
            
        }

        public string Model 
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel,4));
                }

                this.model = value;
            }
        }

        public int HorsePower 
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value >= this.minHorsePower && value <= this.maxHorsePower)
                {
                    this.horsePower = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
            }
        }

        public double CubicCentimeters { get; }

        public  double CalculateRacePoints(int laps)
        {
            return (this.CubicCentimeters / this.HorsePower) * laps;
        }
    }
}
