using System.ComponentModel.DataAnnotations;

namespace MushroomServer.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public Player Player { get; set; }
        public string Name { get; set; }

        public Item() { } // For EntityFramework
        public Item(string name)
        {
            Name = name;
        }
    }
}
