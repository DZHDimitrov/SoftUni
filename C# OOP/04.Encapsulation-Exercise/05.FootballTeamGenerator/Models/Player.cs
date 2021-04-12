using _05.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name,Stats stats)
        {
            Name = name;
            PlayerStats = stats;
        }
        public string Name 
        { 
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_NAME_EXC_MSG);
                }
                name = value;
            }
        }

        public Stats PlayerStats { get; set; }

        public double OverAllSkill => PlayerStats.AverageStats;
    }
}
