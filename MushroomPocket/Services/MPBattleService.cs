using MushroomPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.WebSockets;
using System.Threading;

namespace MushroomPocket.Services
{
    public class MPBattleService
    {
        private HttpClient client;
        private string ServerHost;

        public MPBattleService(string serverHost)
        {
            HttpClientHandler handler = new HttpClientHandler();

            client = new HttpClient(handler);
            client.BaseAddress = new Uri($"http://{serverHost}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            ServerHost = serverHost;
        }

        public async Task<bool> CheckServer()
        {
            HttpResponseMessage res = await client.GetAsync($"/api/battle");
            if (res.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async Task<List<string>> Battle(PocketContext pocketContext, string GUID, Character character)
        {
            List<string> BattleLog = null;

            JoinRequest joinRequest = new JoinRequest()
            {
                GUID = GUID,
                Id = character.Id,
                Name = character.Name,
                HP = character.HP,
                EXP = character.EXP,
                Skill = character.Skill
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(joinRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage res = await client.PostAsync($"/api/battle/join", content);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                BattleLog = new List<string>()
                {
                    "Join Error!"
                };
                return BattleLog;
            }

            string resultIdJson = res.Content.ReadAsStringAsync().Result;
            string resultId = JsonSerializer.Deserialize<string>(resultIdJson);
            Console.WriteLine("Awaiting enemy player...");

            // Websocket
            ClientWebSocket webSocket = new ClientWebSocket();
            await webSocket.ConnectAsync(new Uri($"ws://{ServerHost}/ws/{resultId}"), CancellationToken.None);
            Console.WriteLine("Connected to WebSocket server\n");

            var buffer = new byte[1024 * 4];
            while (true)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None);
                    break;
                }

                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                if (message.StartsWith("Get;"))
                {
                    Console.WriteLine(message.Substring(5));
                    string response = Console.ReadLine();
                    var bytes = Encoding.UTF8.GetBytes(response);
                    await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                    continue;
                }

                if (message.StartsWith("FightChoice;"))
                {
                    string fightChoice = new AdventureService(pocketContext, character).FightChoice();
                    var bytes = Encoding.UTF8.GetBytes(fightChoice);
                    await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                    continue;
                }

                if (message.StartsWith("Red;"))
                {
                    message = message.Substring(5);
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (message.StartsWith("Yellow;"))
                {
                    message = message.Substring(7);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (message.StartsWith("Green;"))
                {
                    message = message.Substring(6);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (message.StartsWith("Blue;"))
                {
                    message = message.Substring(5);
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                Console.WriteLine($"{message}");
                Console.ResetColor();
            }

            // Get Battle Results
            while (BattleLog == null)
            {
                HttpResponseMessage res1 = await client.GetAsync($"/api/battle/result/{resultId}");
                if (res1.StatusCode != HttpStatusCode.OK)
                {
                    BattleLog = new List<string>()
                    {
                        "Join Error!"
                    };
                    return BattleLog;
                }

                string jsonStr = await res1.Content.ReadAsStringAsync();
                BattleResult battleResult = JsonConvert.DeserializeObject<BattleResult>(jsonStr);
                if (battleResult.Status == "Invalid Character")
                {
                    BattleLog = new List<string>()
                    {
                        "Invalid Character!"
                    };
                    break;
                }
                if (battleResult.Status == "Battle Finish")
                {
                    BattleLog = battleResult.BattleLog;
                    character.HP = battleResult.Character.HP;
                    character.EXP = battleResult.Character.EXP;
                    pocketContext.SaveChanges();
                    break;
                }

                await Task.Delay(500);
            }

            return BattleLog;
        }

        public class JoinRequest
        {
            public required string GUID { get; set; }
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int HP { get; set; }
            public required int EXP { get; set; }
            public required string Skill { get; set; }
        }

        public class BattleResult
        {
            public string GUID { get; set; }
            public string ResultID { get; set; }
            public string Status { get; set; }
            public List<string> BattleLog { get; set; }
            public Character Character { get; set; }
        }
    }
}
