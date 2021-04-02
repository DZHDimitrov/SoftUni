using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> ParkingOfCars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            ParkingOfCars = new List<Car>();
        }

        public int Count
         => ParkingOfCars.Count; 
       

        public string AddCar(Car car)
        {
            if (ParkingOfCars.Any(x=>x.RegistrationNumber == car.RegistrationNumber))
            {              
                return "Car with that registration number, already exists!";
            }
            if (capacity == ParkingOfCars.Count)
            {
                return "Parking is full!";
            }
            ParkingOfCars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car currentCar = ParkingOfCars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (currentCar == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            ParkingOfCars.Remove(currentCar);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registration)
        {
            return ParkingOfCars.FirstOrDefault(x => x.RegistrationNumber == registration);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currentNumber in registrationNumbers)
            {
                Car car = ParkingOfCars.FirstOrDefault(x => x.RegistrationNumber == currentNumber);
                ParkingOfCars.Remove(car);
            }
        }
        
    }
}
