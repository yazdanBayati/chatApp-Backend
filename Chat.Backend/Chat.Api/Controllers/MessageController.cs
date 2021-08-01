using AutoMapper;
using Chat.Api.Core.Domains;
using Chat.Api.Dtos;
using Chat.Core.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _repositroy;
        private readonly IMapper _mapper;
        public MessageController(IMessageRepository repositroy, IMapper mapper)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
        }
        /// <summary>
        /// To Get List of Messages
        /// </summary>
        /// <param name="groupId">Provide groupId</param>
        /// <returns>Returns object of type ItemDataReponse as Json result either as a success or failed response call</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<ItemDataReponse<List<ChatMessage>>>> GetList([FromQuery] int groupId)
        {
            var list = await this._repositroy.GetAll().Where(x=> x.GroupId == groupId).ToListAsync();

            var response = new ItemDataReponse<List<ChatMessage>>
            {
                Success = true,
                Data = this._mapper.Map<List<ChatMessage>>(list)
            };

            return Ok(response);
        }
    }
}
