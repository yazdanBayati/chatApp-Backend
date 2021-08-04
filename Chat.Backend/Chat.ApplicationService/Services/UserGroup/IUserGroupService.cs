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
        Task<ItemReponse> Delete(UserGroupDto userGroupDto);
        Task<ItemDataReponse<List<UserGroupDto>>> GetList(int userId);
    }
}
