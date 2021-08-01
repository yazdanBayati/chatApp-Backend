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
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repositroy;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repositroy, IMapper mapper)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
        }

        /// <summary>
        /// To Add new User of entity Model.
        /// </summary>
        /// <param name="ChatGroupDto">Requies parameter of required entity Model</param>
        /// <returns>Returns object of type Reponse as Json result as a success or failed response</returns>
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<ItemReponse>> Add([FromBody] UserDto requestDto)
        {
            //var user = User?.Claims.FullName();
            var entity = this._mapper.Map<User>(requestDto);

            await this._repositroy.AddAsync(entity);
            
            var response = new ItemReponse
            {
                Success = true,
            };

            return Ok(response);
        }
    }
}
