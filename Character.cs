using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MushroomPocket
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int EXP { get; set; }
        public string Skill {  get; set; }

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
