using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IMap map;
        private CarRepository cars;
        private RacerRepository racers;

        public Controller()
        {
            this.map = new Map();
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;
            if (type == "SuperCar")
            {
                car = new SuperCar(make,model,VIN,horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            if (car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarType));
            }
            this.cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null; 
            ICar car = this.cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            if (racer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            this.racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = this.racers.FindBy(racerOneUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            var racerTwo = this.racers.FindBy(racerTwoUsername);
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            var result = this.map.StartRace(racerOne, racerTwo);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in this.racers.Models.OrderByDescending(x=>x.DrivingExperience).ThenBy(x=>x.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
