using MushroomPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
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

        /// <summary>
        /// Give random amount of coins & EXP
        /// </summary>
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
            #region Get Enemy Character
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
            #endregion

            Character EnemyCharacter = AliveEnemies[random.Next(0, AliveEnemies.Count() - 1)];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You encountered {EnemyCharacter.Name} with {EnemyCharacter.HP}!");
            Console.ResetColor();
            Thread.Sleep(1000);

            int FriendlyStrengthBoost = 0;

            while (character.HP > 0 && EnemyCharacter.HP > 0)
            {
                string FriendlyFightChoice = FightChoice();

                string EnemyFightChoice = "Attack";

                if (FriendlyFightChoice == "Run")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{character.Name} ran away");
                    Console.ResetColor();
                    break;
                }

                if (FriendlyFightChoice != "Attack" && FriendlyFightChoice != "Doge")
                {
                    switch (FriendlyFightChoice)
                    {
                        case "Health Potion":
                            character.HP += 150;
                            pocketContext.SaveChanges();
                            break;
                        case "Experience Potion":
                            character.EXP += 100;
                            pocketContext.SaveChanges();
                            break;
                        case "Strength Potion":
                            FriendlyStrengthBoost = 50;
                            break;
                        default:
                            FriendlyFightChoice = FightChoice();
                            break;
                    }
                }

                // Friendly Attack
                if (FriendlyFightChoice == "Attack")
                {
                    Attack(character, EnemyCharacter, false, true, FriendlyStrengthBoost, true);
                    if (FriendlyStrengthBoost > 0)
                    {
                        FriendlyStrengthBoost = 0;
                    }
                }
                Thread.Sleep(1000);

                if (EnemyCharacter.HP <= 0)
                {
                    break;
                }

                // Enemy Attack
                if (EnemyFightChoice == "Attack")
                {
                    Attack(EnemyCharacter, character, FriendlyFightChoice == "Doge", false, 0, false);
                }
                Thread.Sleep(1000);
            }

            pocketContext.SaveChanges();
        }

        /// <summary>
        /// Get fight choice. if inventory selected, consume item.
        /// </summary>
        public string FightChoice()
        {
            Console.WriteLine("");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Doge");
            Console.WriteLine("(3) Inventory");
            Console.WriteLine("(4) Run away");

            int index;
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out index)) { Console.WriteLine("Invalid number!"); continue; }
                if (index < 1 || index > 4) { Console.WriteLine("Index must be between 1 and 4!"); continue; }
                break;
            }

            switch (index)
            {
                case 1:
                    return "Attack";
                case 2:
                    return "Doge";
                case 3:
                    // List Inventory Items
                    if (pocketContext.Inventory.Count() == 0)
                    {
                        Console.WriteLine("You have no items!");
                        return FightChoice();
                    }

                    Dictionary<string, int> counter = new Dictionary<string, int>();
                    foreach (Item item in pocketContext.Inventory.ToList())
                    {
                        if (counter.ContainsKey(item.Name))
                        {
                            counter[item.Name]++;
                        }
                        else
                        {
                            counter.Add(item.Name, 1);
                        }
                    }

                    Console.WriteLine("\nItems:");
                    foreach (KeyValuePair<string, int> item in counter.ToList())
                    {
                        Console.WriteLine($"({counter.ToList().IndexOf(item)}) {item.Value} {item.Key}");
                    }
                    Console.WriteLine("B to return to fight menu");

                    int itemIndex;
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (input.ToLower() == "b") { return FightChoice(); }
                        if (!int.TryParse(input, out itemIndex)) { Console.WriteLine("Invalid number!"); continue; }
                        if (itemIndex < 0 || itemIndex > pocketContext.Inventory.Count()) { Console.WriteLine($"Index must be between 0 and {pocketContext.Inventory.Count()}!"); continue; }
                        break;
                    }
                    string itemChoice = counter.ToList().ElementAt(itemIndex).Key;
                    Console.WriteLine($"You used {itemChoice}");

                    pocketContext.Remove(pocketContext.Inventory.FirstOrDefault(i => i.Name == itemChoice));

                    return itemChoice;
                case 4:
                    return "Run";
                default:
                    return FightChoice();
            }
        }

        /// <summary>
        /// Attack Damage logic
        /// </summary>
        private void Attack(Character char1, Character char2, bool Doge, bool GrantEXP, int StrengthBoost, bool Color)
        {
            int Dmg = SkillDamages[char1.Skill];
            int DmgBoost = (int)Math.Floor((double)char1.EXP / 100) * 5;
            double DogeMultiplier = 1;

            int DogeRandom = random.Next(0, 3);
            if (Doge)
            {
                if (DogeRandom == 0)
                {
                    Console.WriteLine($"{char2.Name} fully doged the attack");
                    DogeMultiplier = 0;
                }
                else
                {
                    Console.WriteLine($"{char2.Name} partially doged the attack");
                    DogeMultiplier = 0.5;
                }
            }

            int DmgDealt = (int)Math.Round((Dmg + DmgBoost) * DogeMultiplier);
            char2.HP = Math.Max(0, char2.HP - DmgDealt);
            if (Color) Console.ForegroundColor = ConsoleColor.Green; else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{char1.Name} used {char1.Skill} and dealt {DmgDealt}");
            Console.WriteLine($"{char2.Name} is now at {char2.HP} HP");
            Console.ResetColor();

            Thread.Sleep(500);
            if (char2.HP <= 0)
            {
                if (Color) Console.ForegroundColor = ConsoleColor.Green; else Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{char2.Name} died, {char1.Name} won!");
                Console.ResetColor();
                if (GrantEXP)
                {
                    int exp = random.Next(20, 50);
                    char1.EXP += exp;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{char1.Name} gained {exp} EXP.");
                    Console.ResetColor();
                }
            }
        }
    }
}
