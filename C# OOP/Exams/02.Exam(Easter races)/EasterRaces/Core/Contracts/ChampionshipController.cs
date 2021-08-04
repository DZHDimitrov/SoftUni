using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Contracts
{
    public class ChampionshipController : IChampionshipController
    {
        DriverRepository drivers = new DriverRepository();
        RaceRepository races = new RaceRepository();
        CarRepository cars = new CarRepository();

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.Models.FirstOrDefault(x => x.Name == driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            ICar car = this.cars.Models.FirstOrDefault(x => x.Model == carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return $"{string.Format(OutputMessages.CarAdded,driverName,carModel)}";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.Models.FirstOrDefault(x => x.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            IDriver driver = this.drivers.Models.FirstOrDefault(x => x.Name == driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return $"{string.Format(OutputMessages.DriverAdded, driverName, raceName)}";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.Models.Any(x=> x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            this.cars.Add(car);


            return $"{string.Format(OutputMessages.CarCreated,type + "Car",model)}";
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.Models.Any(x=>x.Name ==driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            this.drivers.Add(driver);

            return $"{string.Format(OutputMessages.DriverCreated,driverName)}";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.Models.Any(x=>x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            IRace race = new Race(name, laps);
            this.races.Add(race);

            return $"{string.Format(OutputMessages.RaceCreated,name)}";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.Models.FirstOrDefault(x => x.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            Dictionary<IDriver, double> result = new Dictionary<IDriver, double>();

            foreach (var driver in this.drivers.Models)
            {
                var points = driver.Car.CalculateRacePoints(race.Laps);
                result.Add(driver, points);
            }

            var topThree = result.OrderByDescending(x => x.Value).Take(3).ToArray();
            var first = topThree[0];
            var second = topThree[1];
            var third = topThree[2];

            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition,first.Key.Name,raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition,second.Key.Name,raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition,third.Key.Name,raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
