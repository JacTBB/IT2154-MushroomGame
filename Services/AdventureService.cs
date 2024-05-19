using MushroomPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MushroomPocket.Services
{
    public class AdventureService
    {
        private PocketContext pocketContext;
        public Character character;
        private Random random = new Random();

        private static Dictionary<string, int> SkillDamages = new Dictionary<string, int>()
        {
            // Skill Damage - Friendly
            { "Agility", 10 },
            { "Leadership", 15 },
            { "Strength", 20 },
            { "Precision and Accuracy", 30 },
            { "Magic Abilities", 35 },
            { "Combat Skills", 40 },

            // Skill Damage - Hostile
            { "Slam", 25 },
            { "Powerful Bite", 30 },
            { "Fire Breath", 100 },
        };

        private static List<Character> EnemyCharacters = new List<Character>
        {
                new Character("Bowser", 1000, 0, "Fire Breath"),
                new Character("Yoshi", 200, 0, "Powerful Bite"),
                new Character("Whomp", 100, 0, "Slam")
        };

        public AdventureService(PocketContext _pocketContext, Character sentCharacter)
        {
            pocketContext = _pocketContext;
            character = sentCharacter;
        }

        public void Adventure()
        {
            if (random.Next(0, 3) == 0)
            {
                FoundCoin();
            }
            else
            {
                Fight();
            }
        }

        public void FoundCoin()
        {
            int coins = random.Next(2, 5);
            Console.WriteLine($"You went on an adventure and found {coins} coins...");

            if (pocketContext.Coins.FirstOrDefault() == null)
            {
                pocketContext.Coins.Add(new Coins(0));
            }
            pocketContext.Coins.First().Amount += coins;

            int exp = random.Next(5, 10);
            character.EXP += exp;
            Console.WriteLine($"{character.Name} gained {exp} EXP.");

            pocketContext.SaveChanges();
        }

        public void Fight()
        {
            List<Character> AliveEnemies = EnemyCharacters.Where(c => c.HP > 0).ToList();
            if (AliveEnemies.Count == 0)
            {
                Console.WriteLine("All enemies are dead, your adventure continues...");
                return;
            }

            Character EnemyCharacter = AliveEnemies[random.Next(0, AliveEnemies.Count() - 1)];
            Console.WriteLine($"You encountered {EnemyCharacter.Name} with {EnemyCharacter.HP}!");
            Thread.Sleep(1000);

            while (character.HP > 0 && EnemyCharacter.HP > 0)
            {
                // Friendly Attack
                EnemyCharacter.HP = Math.Max(0, EnemyCharacter.HP - SkillDamages[character.Skill]);
                Console.WriteLine($"{character.Name} used {character.Skill} and dealt {SkillDamages[character.Skill]}");
                Console.WriteLine($"{EnemyCharacter.Name} is now at {EnemyCharacter.HP} HP");
                Thread.Sleep(1000);

                if (EnemyCharacter.HP <= 0)
                {
                    Console.WriteLine($"{EnemyCharacter.Name} died, you won!");
                    int exp = random.Next(20, 50);
                    character.EXP += exp;
                    Console.WriteLine($"{character.Name} gained {exp} EXP.");
                    break;
                }

                // Enemy Attack
                character.HP = Math.Max(0, character.HP - SkillDamages[EnemyCharacter.Skill]);
                Console.WriteLine($"{EnemyCharacter.Name} used {EnemyCharacter.Skill} and dealt {SkillDamages[EnemyCharacter.Skill]}");
                Console.WriteLine($"{character.Name} is now at {character.HP} HP");
                Thread.Sleep(1000);

                if (character.HP <= 0)
                {
                    Console.WriteLine($"{character.Name} died, you lost!");
                    int exp = random.Next(5, 10);
                    character.EXP += exp;
                    Console.WriteLine($"{character.Name} gained {exp} EXP.");
                    break;
                }
            }

            pocketContext.SaveChanges();
        }
    }
}
