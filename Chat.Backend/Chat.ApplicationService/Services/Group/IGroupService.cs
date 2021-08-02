using Chat.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Services.Group
{
    public interface IGroupService
    {
        Task<ItemDataReponse<ChatGroupDto>> Add(ChatGroupDto chatGroupDto);

        Task<ItemDataReponse<List<ChatGroupDto>>> GetAll();
    }
}
