using Chat.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Services.UserGroup
{
    public interface IUserGroupSevice
    {
        Task<ItemReponse> Add(UserGroupDto userGroupDto);
        Task<ItemReponse> Delete(int id);
        Task<ItemDataReponse<List<UserGroupDto>>> GetList(int userId);
    }
}
