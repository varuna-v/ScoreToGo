using System;

namespace STG.DataAccess.DataModels
{
    public class Set
    {
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public int SetNumber { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        //rotation history
        //substitutions
        //time outs
    }
}
