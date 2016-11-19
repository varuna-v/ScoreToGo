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
