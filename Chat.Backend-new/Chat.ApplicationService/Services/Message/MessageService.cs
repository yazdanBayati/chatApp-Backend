using AutoMapper;
using Chat.Api.Core.Domains;
using Chat.ApplicationService.Dtos;
using Chat.Core.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Services.Message
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repositroy;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository repositroy, IMapper mapper)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
        }

        public async Task<ItemReponse> Add(ChatMessageDto messageDto)
        {
            var response = new ItemReponse();
            var entity = this._mapper.Map<ChatMessage>(messageDto);
            await this._repositroy.AddAsync(entity);
            response.Success = true;
            return response;
        }

        public async Task<ItemDataReponse<List<ChatMessageDto>>> GetList(int groupId)
        {
            var list = await this._repositroy.GetIQueryable().Where(x => x.GroupId == groupId).ToListAsync();

            var response = new ItemDataReponse<List<ChatMessageDto>>
            {
                Success = true,
                Data = this._mapper.Map<List<ChatMessageDto>>(list)
            };

            return response;
        }
    }
}
