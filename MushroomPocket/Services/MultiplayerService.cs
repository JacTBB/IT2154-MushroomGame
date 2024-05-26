using MushroomServer.Models;
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
using static MushroomServer.Services.MPBattleService;

namespace MushroomServer.Services
{
    public class MultiplayerService
    {
        private HttpClient client;
        private string ServerHost;

        public MultiplayerService(string serverHost)
        {
            HttpClientHandler handler = new HttpClientHandler();

            client = new HttpClient(handler);
            client.BaseAddress = new Uri($"http://{serverHost}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            ServerHost = serverHost;
        }

        public async Task<bool> CheckServer()
        {
            HttpResponseMessage res = await client.GetAsync($"/api");
            if (res.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Connect(string username, string password)
        {
            AccountRequest accountRequest = new AccountRequest()
            {
                Username = username,
                Password = password
            };
            StringContent content = new StringContent(JsonSerializer.Serialize(accountRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PostAsync($"/api/login", content);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Invalid username or password!");
                return false;
            }

            string connectIdJSON = res.Content.ReadAsStringAsync().Result;
            string connectId = JsonSerializer.Deserialize<string>(connectIdJSON);
            Console.WriteLine("Logged in!");

            ClientWebSocket webSocket = new ClientWebSocket();
            try
            {
                await webSocket.ConnectAsync(new Uri($"ws://{ServerHost}/ws/{connectId}"), CancellationToken.None);
            }
            catch
            {
                Console.WriteLine($"Connection failed! Possibly connected on another client.");
                return false;
            }
            Console.WriteLine("Connected!\n");

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
                    Console.WriteLine(message.Substring(4));
                    string response = Console.ReadLine();
                    var bytes = Encoding.UTF8.GetBytes(response);
                    await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                    continue;
                }

                if (message.StartsWith("Red;"))
                {
                    message = message.Substring(4);
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

            Console.WriteLine("Disconnected!");
            return true;
        }

        public async Task<bool> Register(string username, string password)
        {
            AccountRequest accountRequest = new AccountRequest()
            {
                Username = username,
                Password = password
            };
            StringContent content = new StringContent(JsonSerializer.Serialize(accountRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PostAsync($"/api/register", content);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Account already exists!");
                return false;
            }
            Console.WriteLine("Registered!");
            return true;
        }

        public class AccountRequest
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }
    }
}
