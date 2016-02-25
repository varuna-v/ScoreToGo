namespace STGBusiness.DomainModels
{
    public class Game
    {
        public Set[] Sets { get; set; }

        public int[] SetWins { get; set; }

        private int _targetNumberOfSets;
        public int TargetNumberOfSets
        {
            get
            {
                if (_targetNumberOfSets <= 1)
                    _targetNumberOfSets = (int)((Sets.Length + 1) / 2);
                return _targetNumberOfSets;
            }
        }
    }
}
