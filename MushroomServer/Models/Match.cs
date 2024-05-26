namespace MushroomServer.Models
{
    public class Match
    {
        public string MatchID { get; set; }
        public string ResultID { get; set; }
        public string Status { get; set; }
        public List<string> P1BattleLogString { get; set; }
        public List<String> P2BattleLogString { get; set; }
        public Character Character1 { get; set; }
        public Character Character2 { get; set; }

        public Match() { } // For EntityFramework
    }
}
