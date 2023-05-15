using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_2hour.Models
{
    public partial class Matchup
    {
        public string MatchupTeams
        {
            get
            {
                return $"{Team.TeamName} @ {Team1.TeamName}";
            }
        }
        public string MatcupResult
        {
            get
            {
                return $"{Team_Away_Score}-{Team_Home_Score}";
            }
        }
    }
}
