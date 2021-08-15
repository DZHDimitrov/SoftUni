using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int drivingExperience = 10;
        private const string racingBehaviour = "aggressive";

        public StreetRacer(string username, ICar car) 
            : base(username, racingBehaviour, drivingExperience, car)
        {

        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
