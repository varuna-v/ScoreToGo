namespace STG.Domain.Models
{
    public class Player : ModelBase
    {
        public override string IdPrefix
        {
            get
            {
                return "player";
            }
        }

        public string Name { get; set; }
        public int RegistrationNumber { get; set; }
        public int ShirtNumber { get; set; }
    }
}
