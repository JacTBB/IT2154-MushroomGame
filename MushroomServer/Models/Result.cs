namespace MushroomServer.Models
{
    public class Result
    {
        public required string GUID { get; set; }
        public required string ResultID { get; set; }
        public required string Status { get; set; }
        public List<string>? BattleLog { get; set; }
        public Character? Character { get; set; }
    }
}
