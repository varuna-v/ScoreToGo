namespace STG.DataAccess.DataModels
{
    public class Player : RavenDocumentBase
    {
        public string Name { get; set; }
        public int RegistrationNumber { get; set; }
        public int ShirtNumber { get; set; }
    }
}
