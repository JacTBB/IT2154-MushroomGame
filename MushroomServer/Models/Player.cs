using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MushroomServer.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public List<Character> Characters { get; set; }
        public List<Item> Items { get; set; }

        public Player() { } // For EntityFramework
        public Player(string username, string password)
        {
            Username = username;
            Password = password;
            Coins = 0;
            Characters = new List<Character>();
            Items = new List<Item>();
        }

        [NotMapped]
        public Character? CurrentCharacter { get; set; }
        [NotMapped]
        public string? CurrentMatchID { get; set; }
    }
}
