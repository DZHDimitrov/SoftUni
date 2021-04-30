using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private ICollection<Car> cars;

        public Parking(string type,int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count 
        {
            get
            {
                return this.cars.Count;
            } 
        }

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return this.cars.Remove(this.cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));
        }

        public Car GetLatestCar()
        {
            return this.cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return this.cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in this.cars)
            {
                statistics.AppendLine(car.ToString());
            }

            return statistics.ToString().TrimEnd();
        }
    }
}
