using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehaviour;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehaviour, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehaviour;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username 
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                this.username = value;
            }
        }

        public string RacingBehavior 
        {
            get
            {
                return this.racingBehaviour;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                this.racingBehaviour = value;
            }
        }

        public int DrivingExperience 
        {
            get
            {
                return this.drivingExperience;
            }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                this.drivingExperience = value;
            }
        }

        public ICar Car 
        {
            get
            {
                return this.car;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void Race()
        {
            this.Car.Drive();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}")
              .AppendLine($"--Driving behavior: {this.RacingBehavior}")
              .AppendLine($"--Driving experience: {this.DrivingExperience}")
              .AppendLine($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
