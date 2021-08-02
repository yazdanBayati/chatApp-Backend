using AutoMapper;
using Chat.ApplicationService.Dtos;
using Chat.Core.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chat.Api.Core.Domains;
using System.Linq;

namespace Chat.ApplicationService.Services.Group
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repositroy;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository repositroy, IMapper mapper)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
        }
        
        public async Task<ItemDataReponse<ChatGroupDto>> Add(ChatGroupDto chatGroupDto)
        {

            var chatGroup = this._repositroy.GetIQueryable().FirstOrDefault(x => x.Title == chatGroupDto.Title);

            var response = new ItemDataReponse<ChatGroupDto>();

            if (chatGroup == null)
            {
                var entity = this._mapper.Map<ChatGroup>(chatGroupDto);

                await this._repositroy.AddAsync(entity);
                chatGroupDto.Id = entity.Id;
                response.Success = true;
                response.Data = chatGroupDto;
            }
            else
            {
                response.Success = false;
                response.Error = "there is a group by this name";
            }

            return response;

        }

        public async Task<ItemDataReponse<List<ChatGroupDto>>> GetAll()
        {
            var list = await this._repositroy.GetIQueryable().ToListAsync();

            var response = new ItemDataReponse<List<ChatGroupDto>>
            {
                Success = true,
                Data = this._mapper.Map<List<ChatGroupDto>>(list)
            };

            return response;
        }
       
    }
}
