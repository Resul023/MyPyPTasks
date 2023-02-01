using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendToUser(string user, string message, string receiverConnectionId)
            => await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage",user,message);

        public string GetConnectionId() => Context.ConnectionId;
    }
}
