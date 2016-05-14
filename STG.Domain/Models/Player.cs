namespace STG.Domain.Models
{
    public class Player : ModelBase
    {
        public string Name { get; set; }
        public int RegistrationNumber { get; set; }
        public int ShirtNumber { get; set; }
    }
}
