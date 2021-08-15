using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int drivingExperience = 30;
        private const string racingBehaviour = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, racingBehaviour, drivingExperience, car)
        {

        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
