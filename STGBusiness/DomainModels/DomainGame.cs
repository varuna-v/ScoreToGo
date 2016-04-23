using STG.Business.DomainModels;
using System;

namespace STG.Business.DomainModels
{
    public class DomainGame
    {
        public int Id { get; set; }

        public DomainTeam[] Teams { get; set; }

        public DateTime StartedAt { get; set; }

        public DomainGamePlay GamePlay { get; set; }

        //Referees
        //Scorers
        //Location
        //Game number
    }
}
