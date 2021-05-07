using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private ICollection<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => this.pets.Count;

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                this.pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            return this.pets.Remove(this.pets.FirstOrDefault(x => x.Name == name));
        }

        public Pet GetPet(string name, string owner)
        {
            return this.pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return this.pets.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.pets)
            {
                statistics.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return statistics.ToString().TrimEnd();
        }
    }
}
