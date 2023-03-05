using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Models
{
    public partial class Player
    {
        public Int32 Experience
        {
            get
            {
                return DateTime.Now.Year - this.JoinYear.Year;
            }
        }
    }
}
