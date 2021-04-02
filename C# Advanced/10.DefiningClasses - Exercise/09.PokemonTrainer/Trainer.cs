using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name,int numberOfBadges)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            CollectionOfPokemons = new List<Pokemon>();
        }
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> CollectionOfPokemons { get; set; }

        public void AddBadge()
        {
            NumberOfBadges++;
        }
        public void RemoveHealth()
        {
            foreach (var item in CollectionOfPokemons)
            {
                item.Health -= 10;
            }
        }
        public void RemovePokemon()
        {
            CollectionOfPokemons.RemoveAll(x => x.Health <= 0);
        }

    }

}
