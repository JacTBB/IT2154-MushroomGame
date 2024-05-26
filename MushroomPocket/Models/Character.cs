using MushroomServer.Models.Characters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MushroomServer.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
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

        public string Art()
        {
            switch(this.Name)
            {
                case "Daisy": return Daisy.Art;
                case "Luigi": return Luigi.Art;
                case "Mario": return Mario.Art;
                case "Peach": return Peach.Art;
                case "Waluigi": return Waluigi.Art;
                case "Wario": return Wario.Art;
                case "Bowser": return Bowser.Art;
                case "Whomp": return Whomp.Art;
                case "Yoshi": return Yoshi.Art;
                default: return "";
            }
        }
    }
}
