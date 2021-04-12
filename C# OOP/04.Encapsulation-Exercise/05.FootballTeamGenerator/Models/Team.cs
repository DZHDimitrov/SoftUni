using _05.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private readonly ICollection<Player> allPlayers;
        private string name;
        public Team()
        {
            allPlayers = new List<Player>();
        }

        public Team(string name) : this()
        {
            Name = name;
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
                    throw new ArgumentException(String.Format(GlobalConstants.INVALID_NAME_EXC_MSG));
                }
                name = value;
            }
        }
        public IList<Player> AllPlayers 
        {
            get
            {
                return allPlayers.ToList().AsReadOnly();
            }
        }

        public int Rating
        {
            get
            {
                if (allPlayers.Count > 0)
                {
                    return (int)Math.Round(allPlayers.Average(x => x.OverAllSkill));
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddPlayer(Player player)
        {
            allPlayers.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            ValidateAMissingPlayer(playerName);

            Player currentPlayer = allPlayers.FirstOrDefault(x => x.Name == playerName);
            allPlayers.Remove(currentPlayer);
        }
        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }

        private void ValidateAMissingPlayer(string playerName)
        {
            Player currentPlayer = allPlayers.FirstOrDefault(x => x.Name == playerName);
            if (currentPlayer == null)
            {
                throw new ArgumentException($"{String.Format(GlobalConstants.UNEXISTANT_PLAYER_EXC_MSG, playerName, Name)}");
            }
        }

    }
}
