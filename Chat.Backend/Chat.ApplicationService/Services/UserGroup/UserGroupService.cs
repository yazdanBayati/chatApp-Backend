using AutoMapper;
using Chat.ApplicationService.Dtos;
using Chat.Core.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Services.UserGroup
{
    public class UserGroupService : IUserGroupSevice
    {
        private readonly IUserGroupRepositroy _repositroy;
        private readonly IMapper _mapper;

        public UserGroupService(IUserGroupRepositroy repositroy, IMapper mapper)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
        }
        public async Task<ItemReponse> Add(UserGroupDto userGroupDto)
        {
            var count = _repositroy.GetIQueryable().Count();
            var response = new ItemReponse();

            var existItem = await _repositroy.GetIQueryable().FirstOrDefaultAsync(x => x.UserId == userGroupDto.UserId && x.GroupId == userGroupDto.GroupId);
            
            if(existItem == null)
            {
                if (count < 20)// check size of group members
                {
                    var entity = this._mapper.Map<Chat.Core.Domains.UserGroup>(userGroupDto);
                    await this._repositroy.AddAsync(entity);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Can not add more than 20 member to Group";
                }
            }
            else
            {
                response.Success = false;
                response.Error = "this user already assigned to this group";
            }
           

            return response;
        }

        public async Task<ItemReponse> Delete(UserGroupDto userGroupDto)
        {
            var item = await this._repositroy.GetIQueryable().FirstOrDefaultAsync(x => x.UserId == userGroupDto.UserId && x.GroupId == userGroupDto.GroupId);
            await this._repositroy.DeleteAsync(item.Id);
            var response = new ItemDataReponse<ChatGroupDto>
            {
                Success = true,
            };

            return response;
        }

        public async Task<ItemDataReponse<List<UserGroupDto>>> GetList(int userId)
        {
            var list = await this._repositroy.GetIQueryable().Where(x => x.UserId == userId).ToListAsync();

            var response = new ItemDataReponse<List<UserGroupDto>>
            {
                Success = true,
                Data = this._mapper.Map<List<UserGroupDto>>(list)
            };

            return response;
        }
    }
}
