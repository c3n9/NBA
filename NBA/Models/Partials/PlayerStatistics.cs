using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_2hour.Models
{
    public partial class PlayerStatistics
    {
        public double PPGinCareer
        {
            get
            {
                return 0;
            }
        }
        public double APGinCareer
        {
            get
            {                
                return 0;
            }
        }
        public double RPGinCareer
        {
            get
            {
                return 0;
            }
        }
        public double PPGinSeason
        {
            get
            {
                double result = 0;
                if(Matchup.SeasonId == 3)
                {
                    result += Point;
                }
                return result;
            }
        }
        public double APGinSeason
        {
            get
            {
                double result = 0;
                if (Matchup.SeasonId == 3)
                {
                    result += Assist;
                }
                return result;
            }
        }
        public double RPGinSeason
        {
            get
            {
                double result = 0;
                if (Matchup.SeasonId == 3)
                {
                    result += Rebound;
                }
                return result;
            }
        }
    }
}
