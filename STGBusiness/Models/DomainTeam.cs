using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.Business.DomainModels
{
    public class DomainTeam
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Code { get; set; }
        public List<DomainPlayer> Players { get; set; }
        public string GameLetter { get; set; }
    }
}
