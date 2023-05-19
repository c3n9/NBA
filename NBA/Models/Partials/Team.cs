using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_2hour.Models
{
    public partial class Team
    {
        public decimal TotalSalaryTeam
        {
            get
            {
                decimal result = 0;
                PlayerInTeam.Select(x => x.TeamId);
                foreach (var item in PlayerInTeam)
                {
                    if (TeamId == item.TeamId)
                    {
                        result += item.Salary;
                    }
                }
                return result;
            }
        }
    }
}
