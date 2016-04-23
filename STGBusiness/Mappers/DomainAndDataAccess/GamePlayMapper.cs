using STG.Business.DomainModels;
namespace STG.Business.Mappers.DomainAndDataAccess
{
    public class GamePlayMapper : IModelMapper<DomainGamePlay, STG.DataAccess.DataModels.GamePlay>
    {
        public STG.DataAccess.DataModels.GamePlay Map(DomainGamePlay source)
        {
            STG.DataAccess.DataModels.GamePlay target = new STG.DataAccess.DataModels.GamePlay()
            {
                GameId = source.Id,
                EndedAt = source.EndedAt,
                Sets = MapSets(source.Sets)
            };

            return target;
        }

        private STG.DataAccess.DataModels.Set[] MapSets(DomainSet[] sourceSets)
        {
            if (sourceSets == null)
                return null;

            STG.DataAccess.DataModels.Set[] targetSets = new STG.DataAccess.DataModels.Set[sourceSets.Length];

            for (int i = 0; i < sourceSets.Length; i++)
            {
                if (sourceSets[i] == null)
                    continue;
                targetSets[i] = new STG.DataAccess.DataModels.Set()
                {
                    SetNumber = i + 1,
                    TeamAScore = sourceSets[i].Score[0],
                    TeamBScore = sourceSets[i].Score[1],
                    StartedAt = sourceSets[i].StartedAt,
                    EndedAt = sourceSets[i].EndedAt
                };
            }
            return targetSets;
        }


        public DomainGamePlay Map(DataAccess.DataModels.GamePlay source)
        {
            throw new System.NotImplementedException();
        }
    }
}
