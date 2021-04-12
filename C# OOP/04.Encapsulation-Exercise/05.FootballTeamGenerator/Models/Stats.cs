using _05.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        private const double countOfParams = 5;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurcane,int sprint,int dribble,int passing, int shooting)
        {
            Endurance = endurcane;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance 
        {
            get
            {
                return endurance;
            }
            private set
            {
                ValidateStats(value, nameof(Endurance));

                endurance = value;
            }
        }

        public int Sprint 
        { 
            get
            {
                return sprint;
            }
            private set
            {
                ValidateStats(value, nameof(Sprint));

                sprint = value;
            }
        }

        public int Dribble 
        { 
            get
            {
                return dribble;
            }
            private set
            {
                ValidateStats(value, nameof(Dribble));
                dribble = value;
            }
        }

        public int Passing 
        { 
            get
            {
                return passing;
            }
            private set
            {
                ValidateStats(value, nameof(Passing));
                passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                ValidateStats(value, nameof(Shooting));
                shooting = value;
            }
        }

        public double AverageStats => ((Endurance + Sprint + Dribble + Passing + Shooting) * 1.00) / countOfParams;

        private void ValidateStats(int stats,string typeStats)
        {
            if (stats < 0 || stats > 100)
            {
                throw new ArgumentException(String.Format(GlobalConstants.INVALID_STATS_EXC_MSG, typeStats));
            }
        }
    }
}
