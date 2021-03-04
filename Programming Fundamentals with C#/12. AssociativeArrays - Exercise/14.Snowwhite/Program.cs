using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] cmdArgs = input.Split(" <:> ");
                string name = cmdArgs[0];
                string hat = cmdArgs[1];
                int physics = int.Parse(cmdArgs[2]);

                Dwarf currentDwarf = new Dwarf(name,hat,physics);

                if (!dwarfs.Any(x=>x.Name == currentDwarf.Name))
                {
                    dwarfs.Add(currentDwarf);
                }
                else if (dwarfs.FirstOrDefault(x=>x.Name == currentDwarf.Name) != null && dwarfs.FirstOrDefault(x=>x.Name == currentDwarf.Name).Hat != currentDwarf.Hat)
                {
                    dwarfs.Add(currentDwarf);
                }
                else if (dwarfs.FirstOrDefault(x=>x.Name == currentDwarf.Name).Hat == currentDwarf.Hat && dwarfs.FirstOrDefault(x=>x.Name==currentDwarf.Name).Physics<currentDwarf.Physics)
                {
                    dwarfs.Remove(dwarfs.FirstOrDefault(x => x.Name == currentDwarf.Name));
                    dwarfs.Add(currentDwarf);
                }
                input = Console.ReadLine();
            }
            Dictionary<string, List<Dwarf>> orderedDwarfs = new Dictionary<string, List<Dwarf>>();
            foreach (var dwarf in dwarfs.OrderByDescending(x=>x.Physics))
            {
                if (!orderedDwarfs.ContainsKey(dwarf.Hat))
                {
                    orderedDwarfs.Add(dwarf.Hat, new List<Dwarf>());
                }
                orderedDwarfs[dwarf.Hat].Add(dwarf);
            }

            foreach (var item in orderedDwarfs.OrderByDescending(x=>x.Value.Count))
            {
                foreach (var dwrf in item.Value.OrderByDescending(x=>x.Physics))
                {
                    Console.WriteLine(dwrf);
                }
            }
        }
    }
    class Dwarf
    {
        public Dwarf(string name, string hat, int physics)
        {
            Name = name;
            Hat = hat;
            Physics = physics;
        }
        public string Name { get; set; }

        public string Hat { get; set; }

        public int Physics { get; set; }

        public override string ToString()
        {
            return $"({this.Hat}) {this.Name} <-> {this.Physics}";
        }
    }
}
