using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public double AverageRating
        {
            get
            {
                if (ratings.Count == 0)
                {
                    return 0.00;
                }
                else if (ratings.Count == 1)
                {
                    return ratings[0];
                }
                else
                {
                    return ratings.Sum() / ratings.Count;
                }
            }

            set { }
        }

        public List<double> ratings = new List<double>();


        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
        }
        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {AverageRating:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();
            for (int i = 0; i < n; i++)
            {
                string[] array = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = array[0];
                int rarity = int.Parse(array[1]);

                if (plants.Exists(x => x.Name == plant))
                {
                    foreach (var item in plants)
                    {
                        if (item.Name == plant)
                        {
                            item.Rarity += rarity;
                        }
                    }
                }
                else
                {
                    Plant newPlant = new Plant(plant, rarity);
                    plants.Add(newPlant);
                }
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] firstArray = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = firstArray[0].Trim();
                string secondPart = firstArray[1].Trim();
                string[] secondArray = secondPart.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string plantName = secondArray[0].Trim();

                Plant currentPlant = plants.FirstOrDefault(x => x.Name == plantName);

                if (currentPlant == null)
                {
                    Console.WriteLine("error");
                    input = Console.ReadLine();
                    continue;
                }

                if (command == "Rate")
                {
                    int rating = int.Parse(secondArray[1].Trim());
                    Plant currPlant = plants.FirstOrDefault(x => x.Name == plantName);
                    currentPlant.ratings.Add(rating);
                }
                else if (command == "Update")
                {
                    int newRarity = int.Parse(secondArray[1].Trim());
                    Plant currPlant = plants.FirstOrDefault(x => x.Name == plantName);
                    currentPlant.Rarity = newRarity;
                }
                else if (command == "Reset")
                {
                    Plant currPlant = plants.FirstOrDefault(x => x.Name == plantName);
                    currentPlant.ratings.Clear();
                }
                else
                {
                    Console.WriteLine("error");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in plants.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.AverageRating))
            {
                Console.WriteLine(item);
            }

        }

    }
}