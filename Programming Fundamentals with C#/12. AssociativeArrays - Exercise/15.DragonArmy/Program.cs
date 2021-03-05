using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            //private const double damage = 45;
            //private const double health = 250;
            //private const double armor = 10;

            int numberOfDragons = int.Parse(Console.ReadLine());
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string type = cmdArgs[0];
                string name = cmdArgs[1];

                double health;
                double damage;
                double armor;
                Dragon dragon;
                if (!cmdArgs.Contains("null"))
                {
                    health = double.Parse(cmdArgs[2]);
                    damage = double.Parse(cmdArgs[3]);
                    armor = double.Parse(cmdArgs[4]);

                    dragon = new Dragon(name, health, damage, armor);
                }
                else
                {
                    dragon = CreateDragon(cmdArgs.Skip(2).ToArray(),name);        
                }

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new List<Dragon>());
                }
                if (dragons.ContainsKey(type) && dragons[type].Any(x=>x.Name == dragon.Name))
                {
                    Dragon currentDragon = dragons[type].FirstOrDefault(x => x.Name == name);
                    currentDragon.Damage = dragon.Damage;
                    currentDragon.Health = dragon.Health;
                    currentDragon.Armor = dragon.Armor;
                }
                else
                {
                    dragons[type].Add(dragon);
                }
               
            }
            PrintResult(dragons);

        }
        private static void PrintResult(Dictionary<string,List<Dragon>> dragons)
        {
            foreach (var alldragons in dragons)
            {
                Console.WriteLine($"{alldragons.Key}::({AverageDamage(alldragons):f2}/{AverageHealth(alldragons):F2}/{AverageArmor(alldragons):F2})");
                foreach (var dragon in alldragons.Value.OrderBy(x=>x.Name))
                {
                    Console.WriteLine(dragon);
                }
            }
        }

        private static double AverageArmor(KeyValuePair<string, List<Dragon>> dragon)
        {
            return dragon.Value.Sum(x => x.Armor) / dragon.Value.Count ;
        }

        private static double AverageHealth(KeyValuePair<string, List<Dragon>> dragon)
        {
            return dragon.Value.Sum(x => x.Health) / dragon.Value.Count;
        }

        private static double AverageDamage(KeyValuePair<string, List<Dragon>> dragon)
        {
            return dragon.Value.Sum(x => x.Damage) / dragon.Value.Count;
        }

        private static Dragon CreateDragon(string[] arr, string name)
        {
            Dragon dragon = new Dragon(name, 0, 0, 0);
            if (arr[0] == "null")
            {
                dragon.Damage = 45;
            }
            else
            {
                dragon.Damage = double.Parse(arr[0]);
            }
            if (arr[1] == "null")
            {
                dragon.Health = 250;
            }
            else
            {
                dragon.Health = double.Parse(arr[1]);
            }
            if (arr[2] == "null")
            {
                dragon.Armor = 10;
            }
            else
            {
                dragon.Armor = double.Parse(arr[2]);
            }
            return dragon;
        }
    }
    public class Dragon
    {
        
        public Dragon(string name, double damage, double health,  double armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
           
            Armor = armor;
        }

        public string Name { get; set; }
        public double Damage { get; set; }


        public double Health { get; set; }

        public double Armor { get; set; }

        public override string ToString()
        {
            return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
        }
    }
}
