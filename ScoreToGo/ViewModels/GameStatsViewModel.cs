using STG.Domain.Models;

namespace ScoreToGo.ViewModels
{
    public class GameStatsViewModel
    {
        public GameStatsViewModel(GameStats gameStats)
        {
            GameStats = gameStats;
        }

        public GameStats GameStats { get; set; }
        public string FormattedTotalTime
        {
            get { return GameStats.TotalTime.ToString("mm' minutes 'ss' seconds '"); }
        }
        public string WinnerTeamName
        {
            get { return GameStats.Winner == 0 ? "Team A" : "Team B"; }
        }
    }
}