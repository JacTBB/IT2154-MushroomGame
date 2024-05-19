using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using MushroomPocket.Models;

// TODO: ASCII Art?
// TODO: Coins / Powerups system?
// TODO: A use for EXP?
// TODO: Multiplayer??
// TODO: Check Validation

namespace MushroomPocket
{
    class Program
    {
        public static PocketContext pocketContext = new PocketContext();
        public static List<MushroomMaster> MushroomMastersList;
        public static Dictionary<string, string> CharacterSkills = new Dictionary<string, string>();
        public static Dictionary<string, int> SkillDamages = new Dictionary<string, int>();
        public static List<Character> EnemyCharacters = new List<Character>
        {
                new Character("Bowser", 1000, 0, "Fire breath"),
                new Character("Yoshi", 200, 0, "Powerful bite"),
                new Character("Whomp", 100, 0, "Slam")
        };

        public static void Main(string[] args)
        {   
            //MushroomMaster criteria list for checking character transformation availability.   
            /*************************************************************************
                PLEASE DO NOT CHANGE THE CODES FROM LINE 15-19
            *************************************************************************/ 
            List<MushroomMaster> mushroomMasters = new List<MushroomMaster>(){
            new MushroomMaster("Daisy", 2, "Peach"),
            new MushroomMaster("Wario", 3, "Mario"),
            new MushroomMaster("Waluigi", 1, "Luigi")
            };
            MushroomMastersList = mushroomMasters;

            CharacterSkills.Add("Waluigi", "Agility");
            CharacterSkills.Add("Daisy", "Leadership");
            CharacterSkills.Add("Wario", "Strength");
            CharacterSkills.Add("Luigi", "Precision and Accuracy");
            CharacterSkills.Add("Peach", "Magic Abilities");
            CharacterSkills.Add("Mario", "Combat Skills");

            SkillDamages.Add("Agility", 10);
            SkillDamages.Add("Leadership", 15);
            SkillDamages.Add("Strength", 20);
            SkillDamages.Add("Precision and Accuracy", 30);
            SkillDamages.Add("Magic Abilities", 35);
            SkillDamages.Add("Combat Skills", 40);

            SkillDamages.Add("Slam", 25);
            SkillDamages.Add("Powerful bite", 30);
            SkillDamages.Add("Fire breath", 100);

            pocketContext.Database.EnsureCreated();

            while (true) {
                if (!Menu())
                {
                    break;
                }
            }
        }

        public static bool Menu()
        {
            Console.WriteLine(new String('*', 30));
            Console.WriteLine("Welcome to Mushroom Pocket App");
            Console.WriteLine(new String('*', 30));
            Console.WriteLine("(1). Add Mushroom's character to my pocket");
            Console.WriteLine("(2). List character(s) in my pocket");
            Console.WriteLine("(3). Check if I can transform my characters");
            Console.WriteLine("(4). Transform characters(s)");
            Console.WriteLine("(5). Remove characters");
            Console.WriteLine("(6). Begin adventure");
            Console.WriteLine("(7). Revive dead characters to 50 HP");
            Console.WriteLine("Please only enter [1,2,3,4,5,6,7] or Q to quit: ");

            string option = Console.ReadLine();
            Console.WriteLine("\n");

            switch (option.ToLower())
            {
                case "1":
                    Add();
                    break;
                case "2":
                    List();
                    break;
                case "3":
                    CheckTransform();
                    break;
                case "4":
                    Transform();
                    break;
                case "5":
                    Remove();
                    break;
                case "6":
                    Battle();
                    break;
                case "7":
                    Revive();
                    break;
                case "q":
                    return false;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            Console.WriteLine("\n");

            return true;
        }

        public static void Add()
        {
            string name;
            int hp;
            int exp;

            Console.Write("Enter Character's Name: ");
            name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());

            while (true)
            {
                Console.Write("Enter Character's HP: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out hp)) { Console.WriteLine("Invalid number!"); continue; }
                if (hp <= 0 || hp > 200) { Console.WriteLine("HP must be between 1 and 200!"); continue; }
                break;
            }

            while (true)
            {
                Console.Write("Enter Character's EXP: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out exp)) { Console.WriteLine("Invalid number!"); continue; }
                break;
            }

            List<string> AllowedCharacterNames = new List<string>
            {
                "Waluigi",
                "Daisy",
                "Wario"
            };

            if (AllowedCharacterNames.ToList().IndexOf(name) == -1)
            {
                Console.WriteLine("Invalid Character");
                return;
            }

            Character character = new Character
            {
                Name = name,
                HP = hp,
                EXP = exp,
                Skill = CharacterSkills[name]
            };

            pocketContext.Pocket.Add(character);
            pocketContext.SaveChanges();

            Console.WriteLine($"{name} has been added.");
        }

        public static void List()
        {
            foreach (Character character in pocketContext.Pocket.OrderByDescending(c => c.HP).ToList())
            {
                Console.WriteLine(new String('-', 20));
                Console.WriteLine($"Name: {character.Name}");
                Console.WriteLine($"HP: {character.HP}");
                Console.WriteLine($"EXP: {character.EXP}");
                Console.WriteLine($"Skill: {character.Skill}");
                Console.WriteLine(new String('-', 20));
            }
        }

        public static void CheckTransform()
        {
            Dictionary<string, int> Counter = new Dictionary<string, int>
            {
                { "Waluigi", 0 },
                { "Daisy", 0 },
                { "Wario", 0 }
            };
            
            foreach(Character character in pocketContext.Pocket.ToList())
            {
                foreach(MushroomMaster mushroom in MushroomMastersList)
                {
                    if (character.Name == mushroom.Name)
                    {
                        Counter[character.Name]++;
                    }
                }
            }

            foreach(string name in Counter.Keys)
            {
                int count = Counter[name];
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (name == mushroom.Name && count >= mushroom.NoToTransform)
                    {
                        Console.WriteLine($"{name} --> {mushroom.TransformTo}");
                    }
                }
            }
        }

        public static void Transform()
        {
            Dictionary<string, int> Counter = new Dictionary<string, int>
            {
                { "Waluigi", 0 },
                { "Daisy", 0 },
                { "Wario", 0 }
            };

            foreach (Character character in pocketContext.Pocket.ToList())
            {
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (character.Name == mushroom.Name)
                    {
                        Counter[character.Name]++;
                    }
                }
            }

            foreach (string name in Counter.Keys)
            {
                int count = Counter[name];
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (name == mushroom.Name && count >= mushroom.NoToTransform)
                    {
                        Console.WriteLine($"{name} has been transformed to {mushroom.TransformTo}");
                        Character newCharacter = new Character
                        {
                            Name = mushroom.TransformTo,
                            HP = 100,
                            EXP = 0,
                            Skill = CharacterSkills[mushroom.TransformTo]
                        };
                        pocketContext.Add(newCharacter);
                        pocketContext.Pocket.RemoveRange(pocketContext.Pocket.Where(c => c.Name == name).Take(count));
                        pocketContext.SaveChanges();
                    }
                }
            }
        }

        public static void Remove()
        {
            if (pocketContext.Pocket.ToList().Count <= 0)
            {
                Console.WriteLine("You do not have any characters in your pocket.");
                return;
            }

            Console.WriteLine("Enter character name to remove:");
            string characterName = Console.ReadLine();
            List<Character> characters = pocketContext.Pocket.Where(c => c.Name.ToLower() == characterName.ToLower()).ToList();
            
            if (characters.Count == 0) {
                pocketContext.Pocket.Remove(characters.First());
                pocketContext.SaveChanges();
                return;
            }
            else
            {
                Console.WriteLine($"Index - Name - HP - EXP");
                foreach (Character character in characters)
                {
                    Console.WriteLine($"{characters.IndexOf(character)} - {character.Name} - {character.HP} - {character.EXP}");
                }

                string indexString = Console.ReadLine();
                int index;

                if (int.TryParse(indexString, out index) == false)
                {
                    Console.WriteLine("Invalid number");
                    return;
                }

                pocketContext.Pocket.Remove(characters[index]);
                Console.WriteLine("Character successfully removed.");
                pocketContext.SaveChanges();
            }
        }

        public static void Battle()
        {
            int DeadCharactersCount = pocketContext.Pocket.Where(c => c.HP == 0).ToList().Count();
            List<Character> Characters = pocketContext.Pocket.OrderByDescending(c => c.HP).ToList();
            Character CurrentCharacter;

            if (DeadCharactersCount == pocketContext.Pocket.Count())
            {
                Console.WriteLine("All characters are dead, please revive them first.");
                return;
            }

            Console.WriteLine("Choose your character:");
            Console.WriteLine("Name - HP - EXP");
            foreach (Character character in Characters)
            {
                if (character.HP > 0)
                {
                    Console.WriteLine($"{Characters.IndexOf(character)} - {character.Name} - {character.HP} - {character.EXP}");
                }
            }

            while (true)
            {
                int index;
                string input = Console.ReadLine();
                if (!int.TryParse(input, out index)) { Console.WriteLine("Invalid number!"); continue; }
                if (index < 0 || index > Characters.Count()-1) { Console.WriteLine($"Index must be between 0 and {Characters.Count()}!"); continue; }
                CurrentCharacter = Characters[index];
                break;
            }

            Console.WriteLine($"{CurrentCharacter.Name} selected");

            Random random = new Random();

            if (random.Next(0,3) == 0)
            {
                Console.WriteLine("You went on an adventure and found a powerup...");
                int exp = random.Next(5, 10);
                CurrentCharacter.EXP += exp;
                Console.WriteLine($"{CurrentCharacter.Name} gained {exp} EXP.");
            }
            else
            {
                List<Character> AliveEnemies = EnemyCharacters.Where(c => c.HP > 0).ToList();
                if (AliveEnemies.Count == 0)
                {
                    Console.WriteLine("All enemies are dead.");
                    return;
                }

                Character EnemyCharacter = AliveEnemies[random.Next(0, AliveEnemies.Count()-1)];
                Console.WriteLine($"You encountered {EnemyCharacter.Name} with {EnemyCharacter.HP}!");
                Thread.Sleep(500);

                while (CurrentCharacter.HP > 0 && EnemyCharacter.HP > 0)
                {
                    EnemyCharacter.HP = Math.Max(0, EnemyCharacter.HP - SkillDamages[CurrentCharacter.Skill]);
                    Console.WriteLine($"{CurrentCharacter.Name} used {CurrentCharacter.Skill} and dealt {SkillDamages[CurrentCharacter.Skill]}");
                    Thread.Sleep(500);
                    if (EnemyCharacter.HP <= 0)
                    {
                        Console.WriteLine($"{EnemyCharacter.Name} died, you won!");
                        int exp = random.Next(20, 50);
                        CurrentCharacter.EXP += exp;
                        Console.WriteLine($"{CurrentCharacter.Name} gained {exp} EXP.");
                        break;
                    }

                    CurrentCharacter.HP = Math.Max(0, CurrentCharacter.HP - SkillDamages[EnemyCharacter.Skill]);
                    pocketContext.SaveChanges();
                    Console.WriteLine($"{EnemyCharacter.Name} used {EnemyCharacter.Skill} and dealt {SkillDamages[EnemyCharacter.Skill]}");
                    Thread.Sleep(500);
                    if (CurrentCharacter.HP <= 0)
                    {
                        Console.WriteLine($"{CurrentCharacter.Name} died, you lost!");
                        break;
                    }
                }
            }
        }

        public static void Revive()
        {
            foreach (Character character in pocketContext.Pocket.OrderByDescending(c => c.HP).ToList())
            {
                if (character.HP <= 0)
                {
                    character.HP = 50;
                    pocketContext.SaveChanges();

                    Console.WriteLine($"Revived {character.Name} to 50 HP");
                }
            }
        }
    }
}
