using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAdvanced
{
    class Hero
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }

        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HitPoints = hp;
            ManaPoints = mp;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine($" HP: {HitPoints.ToString()}");
            sb.AppendLine($" MP: {ManaPoints.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int heroes = int.Parse(Console.ReadLine());
            List<Hero> allHeroes = new List<Hero>();

            for (int i = 0; i < heroes; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int hp = int.Parse(data[1]);
                int mp = int.Parse(data[2]);
                Hero hero = new Hero(name, hp, mp);
                allHeroes.Add(hero);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] array = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = array[0];
                string heroName = array[1];
                Hero currentHero = allHeroes.FirstOrDefault(x => x.Name == heroName);

                switch (command)
                {
                    case "CastSpell":
                        CastSpell(array, currentHero);
                        break;
                    case "TakeDamage":
                        TakeDamage(array, currentHero, allHeroes);
                        break;
                    case "Recharge":
                        Recharge(array, currentHero);
                        break;
                    case "Heal":
                        Heal(array, currentHero);
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (Hero hero in allHeroes.OrderByDescending(x => x.HitPoints).ThenBy(x => x.Name))
            {
                Console.WriteLine(hero);
            }
        }
        static void CastSpell(string[] array, Hero currentHero)
        {
            string heroName = array[1];
            int mpNeeded = int.Parse(array[2]);
            string spellName = array[3];
            if (currentHero.ManaPoints >= mpNeeded)
            {
                currentHero.ManaPoints -= mpNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currentHero.ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }
        static void TakeDamage(string[] array, Hero currentHero, List<Hero> allHeroes)
        {
            string heroName = array[1];
            int damage = int.Parse(array[2]);
            string attacker = array[3];
            if (currentHero.HitPoints - damage <= 0)
            {
                allHeroes.Remove(currentHero);
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
            else if (currentHero.HitPoints - damage > 0)
            {
                currentHero.HitPoints -= damage;
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHero.HitPoints} HP left!");
            }
        }
        static void Recharge(string[] array, Hero currentHero)
        {
            string heroName = array[1];
            int amountMP = int.Parse(array[2]);
            if (amountMP + currentHero.ManaPoints > 200)
            {
                int neededMp = 200 - currentHero.ManaPoints;
                currentHero.ManaPoints += neededMp;
                Console.WriteLine($"{heroName} recharged for {neededMp} MP!");
            }
            else if (amountMP + currentHero.ManaPoints <= 200)
            {
                currentHero.ManaPoints += amountMP;
                Console.WriteLine($"{heroName} recharged for {amountMP} MP!");
            }
        }
        static void Heal(string[] array, Hero currentHero)
        {
            string heroName = array[1];
            int amountHP = int.Parse(array[2]);
            if (amountHP + currentHero.HitPoints > 100)
            {
                int neededHp = 100 - currentHero.HitPoints;
                currentHero.HitPoints += neededHp;
                Console.WriteLine($"{heroName} healed for {neededHp} HP!");
            }
            else if (amountHP + currentHero.HitPoints <= 100)
            {
                currentHero.HitPoints += amountHP;
                Console.WriteLine($"{heroName} healed for {amountHP} HP!");
            }
        }
    }
}