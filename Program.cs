using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using MushroomPocket.Models;

// TODO: Ensure EFCore SQLite used correctly
// TODO: Remove option
// TODO: Battle / Adventure option
// TODO: Heal option
// TODO: ASCII Art?
// TODO: Coins / Powerups system?
// TODO: Multiplayer??

namespace MushroomPocket
{
    class Program
    {
        public static PocketContext pocketContext = new PocketContext();
        public static List<MushroomMaster> MushroomMastersList;
        public static Dictionary<string, string> CharacterSkills = new Dictionary<string, string>();

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
            Console.WriteLine("Please only enter [1,2,3,4] or Q to quit: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Option1();
                    break;
                case "2":
                    Option2();
                    break;
                case "3":
                    Option3();
                    break;
                case "4":
                    Option4();
                    break;
                case "5":
                    Option5();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            return true;
        }

        public static void Option1()
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
                if (!int.TryParse(input, out hp)) continue;
                break;
            }

            while (true)
            {
                Console.Write("Enter Character's EXP: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out exp)) continue;
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

        public static void Option2()
        {
            foreach (Character character in pocketContext.Pocket.OrderByDescending(c => c.HP).ToList())
            {
                Console.WriteLine(new String('-', 20));
                Console.WriteLine(character.Name);
                Console.WriteLine(character.HP);
                Console.WriteLine(character.EXP);
                Console.WriteLine(character.Skill);
                Console.WriteLine(new String('-', 20));
            }
        }

        public static void Option3()
        {
            foreach(Character character in pocketContext.Pocket.ToList())
            {
                foreach(MushroomMaster mushroom in MushroomMastersList)
                {
                    if (character.Name == mushroom.Name)
                    {
                        Console.WriteLine($"{character.Name} --> {mushroom.TransformTo}");
                    }
                }
            }
        }

        public static void Option4()
        {
            foreach (Character character in pocketContext.Pocket.ToList())
            {
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (character.Name == mushroom.Name)
                    {
                        Console.WriteLine($"{character.Name} has been transformed to {mushroom.TransformTo}");
                        Character newCharacter = new Character{
                            Name = mushroom.TransformTo,
                            HP = 100,
                            EXP = 0,
                            Skill = CharacterSkills[mushroom.TransformTo]
                        };
                        pocketContext.Add(newCharacter);
                        pocketContext.Remove(character);
                        pocketContext.SaveChanges();
                    }
                }
            }
        }

        public static void Option5()
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
    }
}
