namespace MushroomServer.Models
{
    public class Player
    {
        public required string GUID { get; set; }
        public Character? Character { get; set; }
        public string? ResultID { get; set; }
    }
}
