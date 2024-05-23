using Microsoft.AspNetCore.Mvc;
using MushroomServer.Models;
using MushroomServer.Services;
using System.Net.WebSockets;
using System.Text;

namespace MushroomServer.Controllers;

public class WebSocketController : ControllerBase
{
    private MultiplayerService multiplayerService = MultiplayerService.Instance;

    [Route("/ws/{resultId}")]
    [HttpGet]
    public async Task Get(string resultId)
    {
        Result result = multiplayerService.GetResult(resultId);
        if (result == null)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
        multiplayerService.AddWebsocket(resultId, webSocket);

        Console.WriteLine($"WS Connect: {resultId}");
        await WebsocketHandler(resultId, webSocket);
    }

    private async Task WebsocketHandler(string resultId, WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        while (!result.CloseStatus.HasValue)
        {
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

            multiplayerService.Messages.Add(resultId, message);

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }
        if (result.CloseStatus != WebSocketCloseStatus.NormalClosure)
        {
            Console.WriteLine($"WS Close: {resultId}");
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        multiplayerService.RemoveWebsocket(resultId);
        Console.WriteLine($"WS Remove: {resultId}");
    }
}
