using Chat.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Services.Message
{
    public interface IMessageService
    {
        Task<ItemReponse> Add(ChatMessageDto messageDto);

        Task<ItemDataReponse<List<ChatMessageDto>>> GetList(int groupId);
    }
}
