using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            racerOne.Race();
            racerTwo.Race();
            var racerOneMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var racerTwoMultiplier = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceOfWinningPlayerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;
            var chanceOfWinningPlayerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplier;

            if (chanceOfWinningPlayerOne > chanceOfWinningPlayerTwo)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else if (chanceOfWinningPlayerOne < chanceOfWinningPlayerTwo)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
            return "";
        }
    }
}
