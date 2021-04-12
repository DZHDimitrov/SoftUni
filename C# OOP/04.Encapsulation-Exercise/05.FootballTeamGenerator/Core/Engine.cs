using _05.FootballTeamGenerator.Common;
using _05.FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator.Core
{
    class Engine
    {
        private readonly ICollection<Team> allTeams;
        public Engine()
        {
            allTeams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmdArgs = command.Split(';');
                string teamName = cmdArgs[1];
                try
                {
                    switch (cmdArgs[0])
                    {
                        case "Team":
                            AddTeam(cmdArgs.Skip(1).ToArray());
                            break;
                        case "Add":
                            ValidateTeam(cmdArgs.Skip(1).ToArray());

                            AddPlayer(cmdArgs.Skip(1).ToArray());
                            break;
                        case "Remove":
                            RemovePlayer(cmdArgs.Skip(1).ToArray());
                            break;
                        case "Rating":
                            ValidateTeam(cmdArgs.Skip(1).ToArray());

                            ShowRating(cmdArgs.Skip(1).ToArray());
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);                   
                }

                command = Console.ReadLine();
            }
        }



        private void AddTeam(string[] cmdArgs)
        {
            string teamName = cmdArgs[0];
            Team team = new Team(teamName);
            allTeams.Add(team);
        }
        private void AddPlayer(string[] cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];
            int endurance = int.Parse(cmdArgs[2]);
            int sprint = int.Parse(cmdArgs[3]);
            int dribble = int.Parse(cmdArgs[4]);
            int passing = int.Parse(cmdArgs[5]);
            int shooting = int.Parse(cmdArgs[6]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            Player player = new Player(playerName, stats);
            Team team = allTeams.FirstOrDefault(x => x.Name == teamName);

            team.AddPlayer(player);
        }
        private void RemovePlayer(string[] cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];

            Team team = allTeams.FirstOrDefault(x => x.Name == teamName);
            team.RemovePlayer(playerName);
        }
        private void ShowRating(string[] cmdArgs)
        {
            string teamName = cmdArgs[0];
            Team team = allTeams.FirstOrDefault(x => x.Name == teamName);
            Console.WriteLine(team);
        }
        private void ValidateTeam(string[] cmdArgs)
        {
            string teamName = cmdArgs[0];
            Team team = allTeams.FirstOrDefault(x => x.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException(String.Format(GlobalConstants.UNEXISTANT_TEAM_EXC_MSG, teamName));
            }
        }

    }
}
