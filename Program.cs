using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using MushroomPocket.Models;

namespace MushroomPocket
{
    class Program
    {
        public static PocketContext pocketContext = new PocketContext();
        public static List<MushroomMaster> MushroomMastersList;
        public static Dictionary<string, string> TransformedSkills = new Dictionary<string, string>();

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

            TransformedSkills.Add("Luigi", "Precision and Accuracy");
            TransformedSkills.Add("Peach", "Magic Abilities");
            TransformedSkills.Add("Mario", "Combat Skills");

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
            name = Console.ReadLine();

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

            Character character;

            switch (name.ToLower())
            {
                case "waluigi":
                    character = new Waluigi(hp, exp);
                    break;
                case "daisy":
                    character = new Daisy(hp, exp);
                    break;
                case "wario":
                    character = new Wario(hp, exp);
                    break;
                default:
                    Console.WriteLine("Invalid Character");
                    return;
            }

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
                            Skill = TransformedSkills[mushroom.TransformTo]
                        };
                        pocketContext.Add(newCharacter);
                        pocketContext.Remove(character);
                        pocketContext.SaveChanges();
                    }
                }
            }
        }
    }
}
