using System.ComponentModel.DataAnnotations;

namespace MushroomServer.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public Player Player { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int EXP { get; set; }
        public string Skill { get; set; }

        public Character() { } // For EntityFramework
        public Character(string name, int hp, int exp, string skill)
        {
            Name = name;
            HP = hp;
            EXP = exp;
            Skill = skill;
        }
    }
}
