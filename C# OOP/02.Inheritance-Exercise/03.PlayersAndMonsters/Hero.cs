using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    class Hero
    {

        public Hero(string name, int level)
        {
            UserName = name;
            Level = level;
        }
        public string UserName { get; set; }

        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}";
        }
    }
}
