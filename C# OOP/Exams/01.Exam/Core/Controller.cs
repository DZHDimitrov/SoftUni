using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnyRepository = new BunnyRepository();
        private readonly EggRepository eggRepository = new EggRepository();

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            this.bunnyRepository.Add(bunny);
            return $"{String.Format(OutputMessages.BunnyAdded,bunnyType,bunnyName)}";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = this.bunnyRepository.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            IDye dye = new Dye(power);
            bunny.Dyes.Add(dye);

            return $"{String.Format(OutputMessages.DyeAdded,power,bunnyName)}";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggRepository.Add(egg);

            return $"{String.Format(OutputMessages.EggAdded,eggName)}";
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggRepository.FindByName(eggName);
            IWorkshop workshop = new Workshop();
            List<IBunny> bunnies = bunnyRepository.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (bunnies.Any() == false)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            while (bunnies.Any())
            {
                IBunny bunny = bunnies.First();

                while (true)
                {
                    if (bunny.Energy == 0 || bunny.Dyes.All(x=>x.IsFinished()))
                    {
                        bunnies.Remove(bunny);
                        break;
                    }
                    workshop.Color(egg, bunny);

                    if (egg.IsDone())
                    {
                        break;
                    }
                }
                if (egg.IsDone())
                {
                    break;
                }
            }
            var resultMessage = egg.IsDone() == true 
                ? String.Format(OutputMessages.EggIsDone,eggName) 
                : String.Format(OutputMessages.EggIsNotDone, eggName);

            return $"{resultMessage}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.eggRepository.Models.Count(x=>x.IsDone())} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in this.bunnyRepository.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count(x=>!x.IsFinished())} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
