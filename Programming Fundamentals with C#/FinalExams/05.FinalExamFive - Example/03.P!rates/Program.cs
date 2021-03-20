using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.P_rates
{

    public class City
    {
        public City(string cityName, int population, int gold)
        {
            this.CityName = cityName;
            this.Population = population;
            this.Gold = gold;
        }

        public string CityName { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public override string ToString()
        {
            return $"{CityName} -> Population: {Population} citizens, Gold: {Gold} kg";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<City> allCities = GetAllCities();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmdArgs = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];

                if (command == "Plunder")
                {
                    Console.WriteLine(PlunderMethod(allCities, cmdArgs.Skip(1).ToArray()));
                }

                else if (command == "Prosper")
                {
                    Console.WriteLine(ProsperMethod(allCities, cmdArgs.Skip(1).ToArray()));
                }
                input = Console.ReadLine();
            }
            if (allCities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {allCities.Count} wealthy settlements to go to:");

                allCities.OrderByDescending(x => x.Gold).ThenBy(x => x.CityName).ToList().ForEach(x => Console.WriteLine(x));
            }
            else if (allCities.Count <= 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        private static string ProsperMethod(List<City> allCities, string[] cmdArgs)
        {
            string townName = cmdArgs[0];
            int gold = int.Parse(cmdArgs[1]);
            City city = allCities.FirstOrDefault(x => x.CityName == townName);
            StringBuilder sb = new StringBuilder();

            if (gold < 0)
            {
                sb.AppendLine("Gold added cannot be a negative number!");
            }
            else if (gold > 0)
            {
                city.Gold += gold;
                sb.AppendLine($"{gold} gold added to the city treasury. {townName} now has {city.Gold} gold.");
            }

            return sb.ToString().TrimEnd();
        }
        private static string PlunderMethod(List<City> allCities, string[] cmdArgs)
        {
            string plunderedCity = cmdArgs[0];
            int killedPeople = int.Parse(cmdArgs[1]);
            int stolenGold = int.Parse(cmdArgs[2]);

            StringBuilder sb = new StringBuilder();

            City city = allCities.FirstOrDefault(x => x.CityName == plunderedCity);


            city.Population -= killedPeople;
            city.Gold -= stolenGold;

            sb.AppendLine($"{plunderedCity} plundered! {stolenGold} gold stolen, {killedPeople} citizens killed.");

            if (city.Population <= 0 || city.Gold <= 0)
            {
                allCities.Remove(allCities.First(x => x.CityName == plunderedCity));

                sb.AppendLine($"{city.CityName} has been wiped off the map!");
            }

            return sb.ToString().TrimEnd();
        }
        private static List<City> GetAllCities()
        {
            string input = Console.ReadLine();
            List<City> cities = new List<City>();
            while (input != "Sail")
            {
                string[] townInfo = input.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string cityName = townInfo[0];
                int townPopulation = int.Parse(townInfo[1]);
                int townGold = int.Parse(townInfo[2]);

                City city = new City(cityName, townPopulation, townGold);

                if (cities.Any(x => x.CityName == cityName))
                {
                    cities.First(x => x.CityName == city.CityName).Population += city.Population;
                    cities.First(x => x.CityName == city.CityName).Gold += city.Gold;
                }
                else
                {
                    cities.Add(city);
                }

                input = Console.ReadLine();
            }
            return cities;
        }
    }
}
