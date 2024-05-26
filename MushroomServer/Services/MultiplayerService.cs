using MushroomServer.Models;
using System;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

namespace MushroomServer.Services
{
    public class MultiplayerService
    {
        #region Singleton
        private static readonly MultiplayerService instance = new MultiplayerService();
        public static MultiplayerService Instance { get { return instance; } }

        private MultiplayerService() { }
        #endregion

        private DBContext dbContext = new DBContext();
        public List<Player> Players = new List<Player>();
        public Dictionary<string, Result> Results = new Dictionary<string, Result>();
        private Dictionary<string, WebSocket> Websockets = new Dictionary<string, WebSocket>();
        public Dictionary<string, string> Messages = new Dictionary<string, string>();

        //#region BattleVariables
        //private Random random = new Random();

        ///// <summary>
        ///// Base damages for skills of friendly and hostile characters
        ///// </summary>
        //private static Dictionary<string, int> SkillDamages = new Dictionary<string, int>()
        //{
        //    // Skill Damage - Friendly
        //    { "Agility", 10 },
        //    { "Leadership", 15 },
        //    { "Strength", 20 },
        //    { "Precision and Accuracy", 30 },
        //    { "Magic Abilities", 35 },
        //    { "Combat Skills", 40 },

        //    // Skill Damage - Hostile
        //    { "Slam", 25 },
        //    { "Powerful Bite", 30 },
        //    { "Fire Breath", 100 },
        //};
        //#endregion

        ///// <summary>
        ///// Adds player to list of players then checks if battle is eligible.
        ///// </summary>
        //public string? JoinPlayer(Player player)
        //{
        //    string resultId = Guid.NewGuid().ToString();

        //    player.ResultID = resultId;

        //    if (Players.Find(p => p.GUID == player.GUID) != null)
        //    {
        //        return null;
        //    }

        //    Players.Add(player);

        //    Result result = new Result()
        //    {
        //        GUID = player.GUID,
        //        ResultID = resultId,
        //        Status = "Awaiting Players",
        //        Character = player.Character
        //    };

        //    Results.Add(resultId, result);
        //    dbContext.Results.Add(result);
        //    dbContext.SaveChanges();

        //    CheckBattle();

        //    return resultId;
        //}

        ///// <summary>
        ///// Get the result of the battle using resultId.
        ///// </summary>
        //public Result GetResult(string resultId)
        //{
        //    Result result = Results.First(r => r.Key == resultId).Value;
        //    return result;
        //}

        ///// <summary>
        ///// Checks if there are enough players to start a battle.
        ///// </summary>
        //public void CheckBattle()
        //{
        //    if (Players.Count >= 2)
        //    {
        //        StartBattle(Players[0], Players[1]);
        //    }
        //}

        ///// <summary>
        ///// Starts a battle between 2 players and updates the results dictionary.
        ///// </summary>
        //public async void StartBattle(Player player1, Player player2)
        //{
        //    List<string> BattleLog = new List<string>();
        //    Character? character1 = player1.Character;
        //    Character? character2 = player2.Character;

        //    #region Validate Character & Websocket Connection
        //    // Allow Player 2 WS to connect
        //    await Task.Delay(500);

        //    if (character1 == null)
        //    {
        //        Result result = Results.First(r => r.Key == player1.ResultID).Value;
        //        result.Status = "Invalid Character";
        //        Players.Remove(player1);
        //        return;
        //    }
        //    if (character2 == null)
        //    {
        //        Result result = Results.First(r => r.Key == player2.ResultID).Value;
        //        result.Status = "Invalid Character";
        //        Players.Remove(player2);
        //        return;
        //    }

        //    if (Websockets.TryGetValue(player1.ResultID!, out var ws1))
        //    {
        //        if (ws1.State != WebSocketState.Open)
        //        {
        //            Result result = Results.First(r => r.Key == player1.ResultID).Value;
        //            result.Status = "Invalid Character";
        //            Players.Remove(player1);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        Result result = Results.First(r => r.Key == player1.ResultID).Value;
        //        result.Status = "Invalid Character";
        //        Players.Remove(player1);
        //        return;
        //    }

        //    if (Websockets.TryGetValue(player2.ResultID!, out var ws2))
        //    {
        //        if (ws2.State != WebSocketState.Open)
        //        {
        //            Result result = Results.First(r => r.Key == player2.ResultID).Value;
        //            result.Status = "Invalid Character";
        //            Players.Remove(player2);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        Result result = Results.First(r => r.Key == player2.ResultID).Value;
        //        result.Status = "Invalid Character";
        //        Players.Remove(player2);
        //        return;
        //    }
        //    #endregion

        //    SendData(player1.ResultID!, "You are player 1");
        //    SendData(player2.ResultID!, "You are player 2");

        //    BattleLog.Add($"P1 {character1.Name} encountered P2 {character2.Name}!");
        //    SendData(player1.ResultID!, BattleLog.Last(), "Yellow;");
        //    SendData(player2.ResultID!, BattleLog.Last(), "Yellow;");

        //    int char1StrengthBoost = 0;
        //    int char2StrengthBoost = 0;

        //    while (character1.HP > 0 && character2.HP > 0)
        //    {
        //        string char1FightChoice = await GetResponse(player1.ResultID!, "FightChoice;");
        //        string char2FightChoice = await GetResponse(player2.ResultID!, "FightChoice;");

        //        if (char1FightChoice == "Run")
        //        {

        //            BattleLog.Add($"P1 {character1.Name} ran away");
        //            SendData(player1.ResultID!, BattleLog.Last(), "Yellow;");
        //            SendData(player2.ResultID!, BattleLog.Last(), "Yellow;");

        //            int exp = random.Next(5, 10);
        //            character2.EXP += exp;
        //            BattleLog.Add($"P2 {character2.Name} gained {exp} EXP.");
        //            SendData(player2.ResultID!, BattleLog.Last(), "Blue;");
        //            break;
        //        }

        //        if (char2FightChoice == "Run")
        //        {
        //            BattleLog.Add($"P2 {character2.Name} ran away");
        //            SendData(player1.ResultID!, BattleLog.Last(), "Yellow;");
        //            SendData(player2.ResultID!, BattleLog.Last(), "Yellow;");

        //            int exp = random.Next(5, 10);
        //            character1.EXP += exp;
        //            BattleLog.Add($"P1 {character1.Name} gained {exp} EXP.");
        //            SendData(player1.ResultID!, BattleLog.Last(), "Blue;");
        //            break;
        //        }

        //        if (char1FightChoice != "Attack" && char1FightChoice != "Doge")
        //        {
        //            switch (char1FightChoice)
        //            {
        //                case "Health Potion":
        //                    character1.HP += 150;
        //                    break;
        //                case "Experience Potion":
        //                    character1.EXP += 100;
        //                    break;
        //                case "Strength Potion":
        //                    char1StrengthBoost = 50;
        //                    break;
        //                default:
        //                    char1FightChoice = await GetResponse(player1.ResultID!, "FightChoice;");
        //                    break;
        //            }
        //            BattleLog.Add($"P1 {character1.Name} used {char1FightChoice}");
        //            SendData(player1.ResultID!, BattleLog.Last());
        //            SendData(player2.ResultID!, BattleLog.Last());
        //        }

        //        if (char2FightChoice != "Attack" && char2FightChoice != "Doge")
        //        {
        //            switch (char2FightChoice)
        //            {
        //                case "Health Potion":
        //                    character2.HP += 150;
        //                    break;
        //                case "Experience Potion":
        //                    character2.EXP += 100;
        //                    break;
        //                case "Strength Potion":
        //                    char2StrengthBoost = 50;
        //                    break;
        //                default:
        //                    char2FightChoice = await GetResponse(player2.ResultID!, "FightChoice;");
        //                    break;
        //            }
        //            BattleLog.Add($"P2 {character2.Name} used {char2FightChoice}");
        //            SendData(player1.ResultID!, BattleLog.Last());
        //            SendData(player2.ResultID!, BattleLog.Last());
        //        }

        //        // Character 1 Attack
        //        if (char1FightChoice == "Attack")
        //        {
        //            Attack(character1, character2, char2FightChoice == "Doge", true, char1StrengthBoost, player1.ResultID!, player2.ResultID!, BattleLog, false);
        //            if (char1StrengthBoost > 0)
        //            {
        //                char1StrengthBoost = 0;
        //            }
        //        }

        //        if (character2.HP <= 0)
        //        {
        //            break;
        //        }

        //        // Character 2 Attack
        //        if (char2FightChoice == "Attack")
        //        {
        //            Attack(character2, character1, char1FightChoice == "Doge", true, char2StrengthBoost, player2.ResultID!, player1.ResultID!, BattleLog, true);
        //            if (char2StrengthBoost > 0)
        //            {
        //                char2StrengthBoost = 0;
        //            }
        //        }
        //    }

        //    Result result1 = Results.First(r => r.Key == player1.ResultID).Value;
        //    result1.Status = "Battle Finish";
        //    result1.BattleLog = BattleLog;
        //    result1.Character = character1;
        //    Players.Remove(player1);
        //    CloseWebsocket(player1.ResultID!);

        //    Result result2 = Results.First(r => r.Key == player2.ResultID).Value;
        //    result2.Status = "Battle Finish";
        //    result2.BattleLog = BattleLog;
        //    result2.Character = character2;
        //    Players.Remove(player2);
        //    CloseWebsocket(player2.ResultID!);
        //}

        ///// <summary>
        ///// Attack Damage logic
        ///// </summary>
        //private void Attack(Character char1, Character char2, bool Doge, bool GrantEXP, int StrengthBoost, string resultID1, string resultID2, List<string> BattleLog, bool Swap)
        //{
        //    int Dmg = SkillDamages[char1.Skill];
        //    int DmgBoost = (int)Math.Floor((double)char1.EXP / 100) * 5;
        //    double DogeMultiplier = 1;

        //    string char1P = "P1";
        //    string char2P = "P2";
        //    if (Swap)
        //    {
        //        char1P = "P2";
        //        char2P = "P1";
        //    }

        //    int DogeRandom = random.Next(0, 3);
        //    if (Doge)
        //    {
        //        if (DogeRandom == 0)
        //        {
        //            BattleLog.Add($"{char2P} {char2.Name} fully doged the attack");
        //            SendData(resultID1, BattleLog.Last());
        //            SendData(resultID2, BattleLog.Last());
        //            DogeMultiplier = 0;
        //        }
        //        else
        //        {
        //            BattleLog.Add($"{char2P} {char2.Name} partially doged the attack");
        //            SendData(resultID1, BattleLog.Last());
        //            SendData(resultID2, BattleLog.Last());
        //            DogeMultiplier = 0.5;
        //        }
        //    }

        //    int DmgDealt = (int)Math.Round((Dmg + DmgBoost) * DogeMultiplier);
        //    char2.HP = Math.Max(0, char2.HP - DmgDealt);
        //    BattleLog.Add($"{char1P} {char1.Name} used {char1.Skill} and dealt {DmgDealt}");
        //    SendData(resultID1, BattleLog.Last(), "Green;");
        //    SendData(resultID2, BattleLog.Last(), "Red;");
        //    BattleLog.Add($"{char2P} {char2.Name} is now at {char2.HP} HP");
        //    SendData(resultID1, BattleLog.Last(), "Green;");
        //    SendData(resultID2, BattleLog.Last(), "Red;");

        //    Thread.Sleep(500);
        //    if (char2.HP <= 0)
        //    {
        //        BattleLog.Add($"{char2P} {char2.Name} died, P1 {char1.Name} won!");
        //        SendData(resultID1, BattleLog.Last(), "Green;");
        //        SendData(resultID2, BattleLog.Last(), "Red;");
        //        if (GrantEXP)
        //        {
        //            int exp = random.Next(20, 50);
        //            char1.EXP += exp;
        //            BattleLog.Add($"{char1P} {char1.Name} gained {exp} EXP.");
        //            SendData(resultID1, BattleLog.Last(), "Blue;");
        //        }
        //    }
        //}
    }
}
