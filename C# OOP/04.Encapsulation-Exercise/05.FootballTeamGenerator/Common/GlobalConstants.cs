using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator.Common
{
    public static class GlobalConstants
    {
        public const string INVALID_STATS_EXC_MSG = "{0} should be between 0 and 100.";
        public const string INVALID_NAME_EXC_MSG = "A name should not be empty.";
        public const string UNEXISTANT_PLAYER_EXC_MSG = "Player {0} is not in {1} team.";
        public const string UNEXISTANT_TEAM_EXC_MSG = "Team {0} does not exist.";
    }
}
