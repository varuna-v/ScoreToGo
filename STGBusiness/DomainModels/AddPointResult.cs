namespace STGBusiness.DomainModels
{
    public class AddPointResult
    {
        public Game Game { get; set; }

        public PointResultStatus ResultStatus { get; set; }
    }

    public enum PointResultStatus
    {
        Continue,
        EndOfSet,
        EndOfGame
    }
}
