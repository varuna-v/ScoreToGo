using STG.Business.Interfaces;
using System.Linq;
using STG.Domain.Models;

namespace STG.Business
{
    public class GameStatsBusiness : IGameStatsBusiness
    {
        public GameStats GetGameStats(Game game)
        {
            GameStats stats = new GameStats
            {
                GameId = game.UniqueId,
                TotalTime = (game.EndedAt - game.StartedAt),
                TeamInGameStats = new TeamInGameStats[2]
                {
                    new TeamInGameStats(),
                    new TeamInGameStats()
                },
                Winner = game.GamePlay.SetWins[0] > game.GamePlay.SetWins[1] ? 0 : 1
            };
            foreach (Set set in game.GamePlay.Sets)
            {
                if (set == null || set.Information == null || 
                    set.Information[0] == null || set.Information[1] == null)
                    continue;
                stats.TeamInGameStats[set.Winner].NumberOfSetsWon++;
                stats.TeamInGameStats[0].NumberOfTimeOuts += set.Information[0].NumberOfTimeOutsUsed;
                stats.TeamInGameStats[1].NumberOfTimeOuts += set.Information[1].NumberOfTimeOutsUsed;
                stats.TeamInGameStats[0].NumberOfSubstitutions += set.Information[0].Substitutions.ToList().Count(s => s != null);
                stats.TeamInGameStats[1].NumberOfSubstitutions += set.Information[1].Substitutions.ToList().Count(s => s != null);
            }
            return stats;
        }
    }
}
