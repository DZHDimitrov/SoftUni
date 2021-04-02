using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();
            while (input != "Tournament")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (trainers.Any(x => x.Name == trainerName))
                {
                    Trainer currentTrainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                    currentTrainer.CollectionOfPokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, 0);
                    trainer.CollectionOfPokemons.Add(pokemon);
                    trainers.Add(trainer);
                }

                input = Console.ReadLine();
            }
            string secondInput = Console.ReadLine();

            while (secondInput != "End")
            {
                string command = secondInput;


                foreach (var trainer in trainers)
                {
                    if (trainer.CollectionOfPokemons.Any(x=>x.Element == command))
                    {
                        trainer.AddBadge();
                    }
                    else
                    {
                        trainer.RemoveHealth();
                    }
                    if (trainer.CollectionOfPokemons.Any(x=>x.Health <= 0))
                    {
                        trainer.RemovePokemon();
                    }
                }

                secondInput = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x=>x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemons.Count}");
            }
        }
    }
}
