using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations = new DecorationRepository();
        private ICollection<IAquarium> aquariums = new List<IAquarium>();

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            if (aquarium == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }

            this.aquariums.Add(aquarium);
            return $"{string.Format(OutputMessages.SuccessfullyAdded,aquariumType)}";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }

            if (decoration == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);
            return $"{string.Format(OutputMessages.SuccessfullyAdded,decorationType)}";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = null;
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName,fishSpecies,price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            if (fish == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            else
            {
                if ((fishType == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium") ||
                    (fishType == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium"))
                {
                    aquarium.AddFish(fish);
                    return $"{string.Format(OutputMessages.EntityAddedToAquarium,fishType,aquariumName)}";
                }
                else
                {
                    return $"{OutputMessages.UnsuitableWater}";
                }
            }

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var total = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            return $"{string.Format(OutputMessages.AquariumValue,aquariumName,Math.Round(total,2))}";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }
            return $"{string.Format(OutputMessages.FishFed,aquarium.Fish.Count)}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decoration = this.decorations.Models.FirstOrDefault(x => x.GetType().Name == decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            return $"{string.Format(OutputMessages.EntityAddedToAquarium,decorationType,aquariumName)}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
