using System;
namespace STG.Business.DomainModels
{
    public class DomainSet
    {
        public int[] Score { get; set; }

        public DomainTeamRotation[] TeamRotations { get; set; }

        public int FirstServer { get; set; }

        public int Winner { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }
    }
}
