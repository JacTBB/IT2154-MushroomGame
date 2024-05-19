using MushroomPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MushroomPocket.Services
{
    /// <summary>
    /// Adventure Service to handle characters going on adventures.
    /// Has Adventure Logic, EXP Logic, Battle Logic.
    /// </summary>
    public class AdventureService
    {
        private PocketContext pocketContext;
        public Character character;
        private Random random = new Random();

        /// <summary>
        /// Base damages for skills of friendly and hostile characters
        /// </summary>
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

        /// <summary>
        /// List of enemy characters per game session
        /// </summary>
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
            if (random.Next(1, 3) == 1)
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{character.Name} gained {exp} EXP.");
            Console.ResetColor();

            pocketContext.SaveChanges();
        }

        /// <summary>
        /// Randomly selects an enemy.
        /// Friendly does damage according to skill & EXP.
        /// Enemy does fixed damage.
        /// Repeat.
        /// </summary>
        public void Fight()
        {
            List<Character> AliveEnemies = EnemyCharacters.Where(c => c.HP > 0).ToList();
            if (AliveEnemies.Count == 0)
            {
                Console.WriteLine("All enemies are dead, your adventure continues...");
                int exp = random.Next(40, 100);
                character.EXP += exp;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{character.Name} gained {exp} EXP.");
                Console.ResetColor();
                
                // Resets Enemy Characters
                EnemyCharacters = new List<Character>
                {
                        new Character("Bowser", 1000, 0, "Fire Breath"),
                        new Character("Yoshi", 200, 0, "Powerful Bite"),
                        new Character("Whomp", 100, 0, "Slam")
                };
                return;
            }

            Character EnemyCharacter = AliveEnemies[random.Next(0, AliveEnemies.Count() - 1)];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You encountered {EnemyCharacter.Name} with {EnemyCharacter.HP}!");
            Console.ResetColor();
            Thread.Sleep(1000);

            while (character.HP > 0 && EnemyCharacter.HP > 0)
            {
                // Friendly Attack
                int CharacterDamage = SkillDamages[character.Skill];
                int DamageBoost = (int)Math.Floor((double)character.EXP / 100) * 5;
                Console.WriteLine($"{DamageBoost}");
                EnemyCharacter.HP = Math.Max(0, EnemyCharacter.HP - (CharacterDamage + DamageBoost));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{character.Name} used {character.Skill} and dealt {CharacterDamage + DamageBoost}");
                Console.ResetColor();
                Console.WriteLine($"{EnemyCharacter.Name} is now at {EnemyCharacter.HP} HP");
                Thread.Sleep(1000);

                if (EnemyCharacter.HP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{EnemyCharacter.Name} died, you won!");
                    Console.ResetColor();
                    int exp = random.Next(20, 50);
                    character.EXP += exp;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{character.Name} gained {exp} EXP.");
                    Console.ResetColor();
                    break;
                }

                // Enemy Attack
                int EnemyDamage = SkillDamages[EnemyCharacter.Skill];
                character.HP = Math.Max(0, character.HP - EnemyDamage);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{EnemyCharacter.Name} used {EnemyCharacter.Skill} and dealt {SkillDamages[EnemyCharacter.Skill]}");
                Console.ResetColor();
                Console.WriteLine($"{character.Name} is now at {character.HP} HP");
                Thread.Sleep(1000);

                if (character.HP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{character.Name} died, you lost!");
                    Console.ResetColor();
                    int exp = random.Next(5, 10);
                    character.EXP += exp;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{character.Name} gained {exp} EXP.");
                    Console.ResetColor();
                    break;
                }
            }

            pocketContext.SaveChanges();
        }
    }
}
