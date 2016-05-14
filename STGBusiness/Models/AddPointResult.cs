using STG.Domain.Models;
namespace STG.Business.DomainModels
{
    public class AddPointResult
    {
        public GamePlay Game { get; set; }

        public PointResultStatus ResultStatus { get; set; }

        public int? NextServer { get; set; }
    }

    public enum PointResultStatus
    {
        Continue,
        EndOfSet,
        EndOfSetNextDeciding,
        EndOfGame
    }
}
