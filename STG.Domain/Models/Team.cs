using System.Collections.Generic;

namespace STG.Domain.Models
{
    public class Team : ModelBase
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Code { get; set; }
        public string GameLetter { get; set; }
        public List<Player> Players { get; set; }

        public override string IdPrefix
        {
            get
            {
                return "team";
            }
        }
    }
}
