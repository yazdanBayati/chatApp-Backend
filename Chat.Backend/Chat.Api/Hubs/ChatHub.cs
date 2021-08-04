using Chat.Api.Core.Domains;
using Chat.Api.Hubs.Clients;
using Chat.ApplicationService.Dtos;
using Chat.ApplicationService.Services.Group;
using Chat.ApplicationService.Services.Message;
using Chat.ApplicationService.Services.UserGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api
{
    [Authorize]
    public class ChatHub:Hub<IChatClient>
    {
        private readonly IGroupService _groupService;
        private readonly IUserGroupSevice _userGroupService;
        private readonly IMessageService _messageSevice;
        public ChatHub(IGroupService groupService, IUserGroupSevice userGroupService, IMessageService messageSevice)
        {
            this._groupService = groupService;
            this._userGroupService = userGroupService;
            this._messageSevice = messageSevice;
        }
        public async Task SendMessageToGroup(ChatMessageDto message)
        {
            await BroadCastMessageToGroup(message);

            /// <summary>
            /// for performance reaseon first call the hub service to send the message to clinet sooner
            /// its better use Async call to keep the data consistency(AMPQ protocol)
            /// </summary>
            await this._messageSevice.Add(message);
        }

        private async Task BroadCastMessageToGroup(ChatMessageDto message)
        {
            var groupName = IdToGroupName(message.GroupId);
            await Clients.Group(groupName).ReceiveMessage(message);
        }

        public async Task<ItemReponse> CreateGroup(ChatGroupDto group)
        {
            var response  = await this._groupService.Add(group);
            if (response.Success)
            {
                await Clients.All.AddGroup(response.Data);
            }

            return response;
        }

        public override  Task OnConnectedAsync()
        {
            AssignCurrentUserGroups();
            return base.OnConnectedAsync();
        }

        private void AssignCurrentUserGroups()
        {
            var response = this._userGroupService.GetList(Convert.ToInt32(Context.User.Identity.Name)).Result;

            foreach (var group in response.Data)
            {
                var groupName = IdToGroupName(group.GroupId);
                Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task<ItemReponse> JoinGroup(UserGroupDto userGroupDto)
        {
            var response = await this._userGroupService.Add(userGroupDto);
            if (response.Success)
            {
                var groupName = IdToGroupName(userGroupDto.GroupId);
                await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            }
            await LoadGroupHistroy(userGroupDto);

            return response;
        }

        private async Task LoadGroupHistroy(UserGroupDto userGroupDto)
        {
            var getUserListResponse = await this._messageSevice.GetList(userGroupDto.GroupId);

            if (getUserListResponse.Success)
            {
                foreach (var message in getUserListResponse.Data)
                {
                    await Clients.Caller.ReceiveMessage(message);
                }
            }
        }

        public async Task<ItemReponse> LeftGroup(UserGroupDto userGroupDto)
        {
            var rsp= await this._userGroupService.Delete(userGroupDto);
            if (rsp.Success)
            {
                var groupName = IdToGroupName(userGroupDto.GroupId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            }
            return rsp;
        }

        private string IdToGroupName(int listId) => $"chat-group-{listId}";
    }
}
