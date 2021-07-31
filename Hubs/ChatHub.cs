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
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task TriggerGroup(string groupName, ChatMessage message)
        {
            
            await Clients.Groups(groupName).ReceiveMessage(message);
        }
    }
}
