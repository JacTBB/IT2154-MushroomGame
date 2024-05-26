namespace MushroomServer.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int EXP { get; set; }
        public string Skill { get; set; }

        public Character(string name, int hp, int exp, string skill)
        {
            Name = name;
            HP = hp;
            EXP = exp;
            Skill = skill;
        }
    }
}
