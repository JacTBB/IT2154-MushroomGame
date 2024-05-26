// Jackie Soon 221139Y //
using MushroomServer.Models;
using System.Net.WebSockets;
using System.Text;

namespace MushroomServer.Services
{
    public class WebsocketService
    {
        #region Singleton
        private static readonly WebsocketService instance = new WebsocketService();
        public static WebsocketService Instance { get { return instance; } }

        private WebsocketService() { }
        #endregion

        private Dictionary<string, WebSocket> Websockets = new Dictionary<string, WebSocket>();
        public Dictionary<string, string> Messages = new Dictionary<string, string>();
        public Dictionary<string, int> ConnectedPlayers = new Dictionary<string, int>();

        /// <summary>
        /// Adds websocket to list of active websockets.
        /// </summary>
        public void AddWebsocket(string id, Player player, WebSocket websocket)
        {
            Websockets.TryAdd(id, websocket);
            ConnectedPlayers.TryAdd(id, player.Id);
        }

        /// <summary>
        /// Removes websocket from active websockets list.
        /// </summary>
        public void RemoveWebsocket(string id)
        {
            Websockets.Remove(id);
            ConnectedPlayers.Remove(id);
        }

        /// <summary>
        /// Closes the websocket.
        /// </summary>
        public void CloseWebsocket(string id)
        {
            if (Websockets.TryGetValue(id, out WebSocket websocket))
            {
                Console.WriteLine($"WS Close: {id}");
                websocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Finished Battle", CancellationToken.None);
            }
        }

        /// <summary>
        /// Sends a message to client.
        /// </summary>
        public void SendData(string id, string data, string color = "")
        {
            if (Websockets.TryGetValue(id, out var socket) && socket.State == WebSocketState.Open)
            {
                var bytes = Encoding.UTF8.GetBytes(color + data);
                socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        /// <summary>
        /// Sends a message to client and awaits a response.
        /// </summary>
        public async Task<string> GetResponse(string id, string data)
        {
            if (Websockets.TryGetValue(id, out var socket) && socket.State == WebSocketState.Open)
            {
                SendData(id, data);

                if (Messages.ContainsKey(id))
                {
                    Messages.Remove(Messages.First(m => m.Key == id).Key);
                }

                while (Messages.ContainsKey(id) != true)
                {
                    await Task.Delay(100);
                }
                return Messages.First(m => m.Key == id).Value;
            }
            return "";
        }
    }
}
