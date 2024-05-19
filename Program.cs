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
using MushroomPocket.Models.Characters;
using MushroomPocket.Services;

// TODO: Implement GUID
// TODO: ASCII Art?
// TODO: Powerups system?
// TODO: Shop
// TODO: A use for EXP? Damage Multiplier
// TODO: Multiplayer??

namespace MushroomPocket
{
    class Program
    {
        public static List<MushroomMaster> MushroomMastersList;

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

            using (PocketContext pocketContext = new PocketContext())
            {
                pocketContext.Database.EnsureCreated();
            }

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
            Console.WriteLine("(7). Revive dead characters to 100 HP");
            Console.WriteLine("(8). Show coins");
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
                    Adventure();
                    break;
                case "7":
                    Revive();
                    break;
                case "8":
                    ShowCoins();
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
                if (exp <= 0 || exp > 500) { Console.WriteLine("EXP must be between 1 and 500!"); continue; }
                break;
            }

            Character character;
            switch (name)
            {
                case "Waluigi":
                    character = new Waluigi(hp, exp);
                    break;
                case "Daisy":
                    character = new Daisy(hp, exp);
                    break;
                case "Wario":
                    character = new Wario(hp, exp);
                    break;
                default:
                    Console.WriteLine("Invalid Character");
                    return;
            }
            Console.WriteLine(character.Skill);

            using (PocketContext pocketContext = new PocketContext())
            {
                pocketContext.Pocket.Add(character);
                pocketContext.SaveChanges();
            }

            Console.WriteLine($"{name} has been added.");
        }

        public static void List()
        {
            using (PocketContext pocketContext = new PocketContext())
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
        }

        public static void CheckTransform()
        {
            Dictionary<string, int> Counter = new Dictionary<string, int>
            {
                { "Waluigi", 0 },
                { "Daisy", 0 },
                { "Wario", 0 }
            };

            using (PocketContext pocketContext = new PocketContext())
            {
                foreach (Character character in pocketContext.Pocket.ToList())
                {
                    foreach(MushroomMaster mushroom in MushroomMastersList)
                    {
                        if (character.Name == mushroom.Name)
                        {
                            Counter[character.Name]++;
                        }
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

            using (PocketContext pocketContext = new PocketContext())
            {
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

                            Character newCharacter;
                            switch (mushroom.TransformTo)
                            {
                                case "Luigi":
                                    newCharacter = new Luigi();
                                    break;
                                case "Peach":
                                    newCharacter = new Peach();
                                    break;
                                case "Mario":
                                    newCharacter = new Mario();
                                    break;
                                default:
                                    return;
                            }

                            pocketContext.Add(newCharacter);
                            pocketContext.Pocket.RemoveRange(pocketContext.Pocket.Where(c => c.Name == name).Take(count));
                            pocketContext.SaveChanges();
                        }
                    }
                }
            }

        }

        public static void Remove()
        {
            using (PocketContext pocketContext = new PocketContext())
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

        public static void Adventure()
        {
            using (PocketContext pocketContext = new PocketContext())
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

                AdventureService adventureService = new AdventureService(pocketContext, CurrentCharacter);
                adventureService.Adventure();
            }
        }

        public static void Revive()
        {
            using (PocketContext pocketContext = new PocketContext())
            {
                foreach (Character character in pocketContext.Pocket.OrderByDescending(c => c.HP).ToList())
                {
                    if (character.HP <= 0)
                    {
                        character.HP = 100;
                        pocketContext.SaveChanges();

                        Console.WriteLine($"Revived {character.Name} to 100 HP");
                    }
                }
            }
        }
    
        public static void ShowCoins()
        {
            using (PocketContext pocketContext = new PocketContext())
            {
                if (pocketContext.Coins.FirstOrDefault() == null)
                {
                    pocketContext.Coins.Add(new Coins(0));
                    pocketContext.SaveChanges();
                }

                int Coins = pocketContext.Coins.First().Amount;
                Console.WriteLine($"You have {Coins} coins.");
            }
        }
    }
}
