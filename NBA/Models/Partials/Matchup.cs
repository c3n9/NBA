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
        public string MatcupStatus
        {
            get
            {
                string result = string.Empty;
                if (Status == 1)
                    result = "Finished";
                if (Status == -1)
                    result = "Not Start";
                return result;
            }
        }

        public string MatcupStatusBool
        {
            get
            {
                string result = string.Empty;
                if (Status == 1)
                    result = "Yes";
                if (Status == -1)
                    result = "No";
                return result;
            }
        }
    }
}
