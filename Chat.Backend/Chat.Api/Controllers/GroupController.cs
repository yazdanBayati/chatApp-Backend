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
    [Route("groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _repositroy;
        private readonly IMapper _mapper;
        public GroupController(IGroupRepository repositroy, IMapper mapper)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
        }

        /// <summary>
        /// To Add new Group of entity Model.
        /// </summary>
        /// <param name="ChatGroupDto">Requies parameter of required entity Model</param>
        /// <returns>Returns object of type Reponse as Json result as a success or failed response</returns>
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<ItemReponse>> Add([FromBody] ChatGroupDto requestDto)
        {
            //var user = User?.Claims.FullName();
            var entity = this._mapper.Map<ChatGroup>(requestDto);

            await this._repositroy.AddAsync(entity);
            
            var response = new ItemReponse
            {
                Success = true,
            };

            return Ok(response);
        }

        /// <summary>
        /// To Get List of Group
        /// </summary>
        /// <returns>Returns object of type ItemDataReponse as Json result either as a success or failed response call</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<ItemDataReponse<List<ChatGroupDto>>>> GetList()
        {
            var list  = await this._repositroy.GetAll().ToListAsync();

            var response = new ItemDataReponse<List<ChatGroupDto>>
            {
                Success = true,
                Data = this._mapper.Map<List<ChatGroupDto>>(list)
            };

            return Ok(response);
        }
    }
}
