using System.Collections.Generic;

namespace STG.DataAccess.DataModels
{
    public class Team : RavenDocumentBase
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Code { get; set; }
        public string GameLetter { get; set; }
        public List<Player> Players { get; set; }
    }
}
