using MushroomServer.Models;
using System;

namespace MushroomServer.Services
{
    public class MultiplayerService
    {
        #region Singleton
        private static readonly MultiplayerService instance = new MultiplayerService();
        public static MultiplayerService Instance { get { return instance; } }

        private MultiplayerService() { }
        #endregion

        public List<Player> Players = new List<Player>();
        public Dictionary<string, Result> Results = new Dictionary<string, Result>();

        #region BattleVariables
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
        #endregion

        public string? JoinPlayer(Player player)
        {
            string resultId = Guid.NewGuid().ToString();

            player.ResultID = resultId;

            if (Players.Find(p => p.GUID == player.GUID) != null) {
                return null;
            }

            Players.Add(player);
            Results.Add(resultId, new Result()
            {
                GUID = player.GUID,
                ResultID = resultId,
                Status = "Awaiting Players"
            });

            CheckBattle();

            return resultId;
        }

        public Result GetResult(string resultId)
        {
            foreach (var r in Results)
            {
                Console.WriteLine(r.Key);
            }
            Result result = Results.First(r => r.Key == resultId).Value;
            return result;
        }

        public void CheckBattle()
        {
            if (Players.Count >= 2)
            {
                StartBattle(Players[0], Players[1]);
            }
        }

        public void StartBattle(Player player1, Player player2)
        {
            List<string> BattleLog = new List<string>();
            Character? character1 = player1.Character;
            Character? character2 = player2.Character;

            if (character1 == null)
            {
                Result result = Results.First(r => r.Key == player1.ResultID).Value;
                result.Status = "Invalid Character";
                Players.Remove(player1);
                return;
            }
            if (character2 == null)
            {
                Result result = Results.First(r => r.Key == player2.ResultID).Value;
                result.Status = "Invalid Character";
                Players.Remove(player2);
                return;
            }

            BattleLog.Add($"{character1.Name} encountered {character2.Name}!");

            while (character1.HP > 0 && character2.HP > 0)
            {
                // Character 1 Attack
                int Character1Damage = SkillDamages[character1.Skill];
                int DamageBoost1 = (int)Math.Floor((double)character1.EXP / 100) * 5;
                character2.HP = Math.Max(0, character2.HP - (Character1Damage + DamageBoost1));
                BattleLog.Add($"{character1.Name} used {character1.Skill} and dealt {Character1Damage + DamageBoost1}");
                BattleLog.Add($"{character2.Name} is now at {character2.HP} HP");

                if (character2.HP <= 0)
                {
                    BattleLog.Add($"{character2.Name} died, {character1.Name} won!");
                    int exp = random.Next(20, 50);
                    character1.EXP += exp;
                    BattleLog.Add($"{character1.Name} gained {exp} EXP");
                    break;
                }

                // Character 2 Attack
                int Character2Damage = SkillDamages[character2.Skill];
                int DamageBoost2 = (int)Math.Floor((double)character2.EXP / 100) * 5;
                character1.HP = Math.Max(0, character1.HP - (Character2Damage + DamageBoost2));
                BattleLog.Add($"{character2.Name} used {character2.Skill} and dealt {Character2Damage + DamageBoost2}");
                BattleLog.Add($"{character1.Name} is now at {character1.HP} HP");

                if (character1.HP <= 0)
                {
                    BattleLog.Add($"{character1.Name} died, {character2.Name} won!");
                    int exp = random.Next(20, 50);
                    character2.EXP += exp;
                    BattleLog.Add($"{character2.Name} gained {exp} EXP");
                    break;
                }
            }

            Result result1 = Results.First(r => r.Key == player1.ResultID).Value;
            result1.Status = "Battle Finish";
            result1.BattleLog = BattleLog;
            result1.Character = character1;
            Players.Remove(player1);

            Result result2 = Results.First(r => r.Key == player2.ResultID).Value;
            result2.Status = "Battle Finish";
            result2.BattleLog = BattleLog;
            result2.Character = character2;
            Players.Remove(player2);
        }
    }
}
