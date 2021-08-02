using Chat.ApplicationService.Dtos;
using Chat.ApplicationService.Services.Message;
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
        private readonly IMessageService _service;
        public MessageController(IMessageService service)
        {
            this._service = service;
        }
        /// <summary>
        /// To Get List of Messages
        /// </summary>
        /// <param name="groupId">Provide groupId</param>
        /// <returns>Returns object of type ItemDataReponse as Json result either as a success or failed response call</returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("{groupId}/getgroupmessages")]
        
        public async Task<ActionResult<ItemDataReponse<List<ChatMessageDto>>>> GetList(int groupId)
        {
            var response = await this._service.GetList(groupId);
            return Ok(response);
        }
    }
}
