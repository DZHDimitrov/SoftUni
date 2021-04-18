using _06.Raiding.Contracts;
using _06.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Raiding.Core
{
    public class Engine : IEngine
    {
        private const string INVALID_HERO_MSG = "Invalid hero!";
        private readonly ICollection<BaseHero> heroes;
        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int heroesToCreate = int.Parse(Console.ReadLine());
            BaseHero hero = null;

            while (heroes.Count != heroesToCreate)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    hero = GetHero(heroType, heroName);
                    heroes.Add(hero);
                }

                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
                
            
            int bossHealth = int.Parse(Console.ReadLine());
            int sumAllSpells = 0;
            foreach (BaseHero currentHero in heroes)
            {
                Console.WriteLine(currentHero.CastAbility());
                sumAllSpells += currentHero.Power;
            }
            if (bossHealth <= sumAllSpells)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

        private BaseHero GetHero(string type, string name)
        {
            BaseHero hero = null;
            if (type != "Druid" && type != "Paladin" && type != "Warrior" && type != "Rogue")
            {
                throw new InvalidOperationException(INVALID_HERO_MSG);
            }
            else
            {
                if (type == "Druid")
                {
                    hero = new Druid(name);
                }
                else if (type == "Paladin")
                {
                    hero = new Paladin(name);
                }
                else if (type == "Warrior")
                {
                    hero = new Warrior(name);
                }
                else if (type == "Rogue")
                {
                    hero = new Rogue(name);
                }
            }
            return hero;
        }
    }
}
