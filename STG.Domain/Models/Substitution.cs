using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.Domain.Models
{
    public class Substitution
    {
        public int PlayerGoingIn { get; set; }
        public int PlayerComingOut { get; set; }
        public int RequestedTeamScore { get; set; }
        public int OpponentScore { get; set; }
    }
}
