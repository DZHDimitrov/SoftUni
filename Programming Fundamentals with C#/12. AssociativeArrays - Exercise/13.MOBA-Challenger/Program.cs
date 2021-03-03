using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Position>> players = new Dictionary<string, List<Position>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                
                string[] cmdArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string player = cmdArgs[0];
                if (cmdArgs.Contains("vs"))
                {
                    cmdArgs = string.Join("", cmdArgs).Split("vs",StringSplitOptions.RemoveEmptyEntries);
                    string playerTwo = cmdArgs[1];

                    if (players.ContainsKey(player) && players.ContainsKey(playerTwo) && PlayersHaveInCommon(players, player, playerTwo))
                    {
                        int firstPlayerMaxPoints = GetMaxPointsFromPlayers(players, player);
                        int secondPlayerMaxPoints = GetMaxPointsFromPlayers(players, playerTwo);

                        if (firstPlayerMaxPoints > secondPlayerMaxPoints)
                        {
                            players.Remove(playerTwo);
                        }
                        else if (firstPlayerMaxPoints < secondPlayerMaxPoints)
                        {
                            players.Remove(player);
                        }
                    }
                }
                else if (cmdArgs.Contains("->"))
                {
                    cmdArgs = string.Join("", cmdArgs).Split("->", StringSplitOptions.RemoveEmptyEntries);

                    Position position = new Position(cmdArgs[1], int.Parse(cmdArgs[2]));
                    if (!players.ContainsKey(player))
                    {
                        players.Add(player, new List<Position>() { position });
                    }
                    else
                    {
                        if (players[player].Any(x => x.Name == position.Name) && players[player].FirstOrDefault(x => x.Name == position.Name).Points < position.Points)
                        {
                            players[player].FirstOrDefault(x => x.Name == position.Name).Points = position.Points;
                        }
                        else if (!players[player].Any(x=>x.Name==position.Name))
                        {
                            players[player].Add(position);
                        }
                    }
                }
                



                input = Console.ReadLine();
            }
            foreach (var item in players.OrderByDescending(x=>x.Value.Sum(x=>x.Points)).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Sum(x=>x.Points)} skill");
                foreach (var pos in item.Value.OrderByDescending(x=>x.Points).ThenBy(x=>x.Name))
                {
                    Console.WriteLine($"- {pos.Name} <::> {pos.Points}");
                }
            }
        }
        private static int GetMaxPointsFromPlayers(Dictionary<string, List<Position>> players, string player)
        {
            var firstPlayer = players.FirstOrDefault(x => x.Key == player);
            int points = 0;
            foreach (var item in firstPlayer.Value)
            {
                points += item.Points;
            }
            return points;
            
        }
        private static bool PlayersHaveInCommon(Dictionary<string,List<Position>> players,string playerOne,string playerTwo)
        {
            var firstPlayer = players.FirstOrDefault(x => x.Key == playerOne);
            var secondPlayer = players.FirstOrDefault(x => x.Key == playerTwo);
            foreach (var pos in firstPlayer.Value)
            {
                foreach (var position in secondPlayer.Value)
                {
                    if (pos.Name == position.Name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class Position
    {
        public Position(string name, int points)
        {
            Name = name;
            Points = points;
        }
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
