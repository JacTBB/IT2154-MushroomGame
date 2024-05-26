// Jackie Soon 221139Y //
using Microsoft.AspNetCore.Mvc;
using MushroomServer.Models;
using MushroomServer.Services;
using System.Net.WebSockets;
using System.Text;

namespace MushroomServer.Controllers;

public class WebSocketController : ControllerBase
{
    private AccountService accountService = AccountService.Instance;
    private WebsocketService websocketService = WebsocketService.Instance;

    [Route("/ws/{connectId}")]
    [HttpGet]
    public async Task Get(string connectId)
    {
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        if (accountService.PlayerSessions.TryGetValue(connectId, out Player player)) {
            if (websocketService.ConnectedPlayers.ContainsValue(player.Id))
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            websocketService.AddWebsocket(connectId, player, webSocket);

            Console.WriteLine($"WS Connect: {connectId} {player.Username}");
            GameService gameService = new GameService(player, connectId);
            gameService.Main();
            await WebsocketHandler(connectId, webSocket, gameService);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
    }

    private async Task WebsocketHandler(string connectId, WebSocket webSocket, GameService gameService)
    {
        try
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                websocketService.Messages.Add(connectId, message);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            if (result.CloseStatus != WebSocketCloseStatus.NormalClosure)
            {
                Console.WriteLine($"WS Close: {connectId}");
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
        }
        catch { }

        gameService.Stopped = true;
        websocketService.RemoveWebsocket(connectId);
        Console.WriteLine($"WS Remove: {connectId}");
    }
}
