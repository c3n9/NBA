using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_2hour.Models
{
    public partial class Player
    {
        public int ExperienseInNBA
        {
            get
            {
                return JoinYear.Year-DateOfBirth.Year;
            }
        }
        
        

    }
}
