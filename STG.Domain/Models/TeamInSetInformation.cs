namespace STG.Domain.Models
{
    public class TeamInSetInformation
    {
        public Substitution[] Substitutions { get; set; }
        public TimeOut[] TimeOuts { get; set; }
        public int NumberOfTimeOutsUsed { get; set; }
        //rotation history
    }
}
