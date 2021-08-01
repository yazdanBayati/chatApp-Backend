using Chat.Api.Core.Domains;
using Chat.Api.Hubs.Clients;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api
{
    public class ChatHub:Hub<IChatClient>
    {
        public async Task SendMessageToGroup(ChatMessageDto message)
        {
            await Clients.Group(message.GroupName).ReceiveMessage(message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
