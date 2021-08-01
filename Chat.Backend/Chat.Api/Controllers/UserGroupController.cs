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
    [Route("usergroups")]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupRepository _repositroy;
        private readonly IMapper _mapper;
        public UserGroupController(IUserGroupRepository  repositroy, IMapper mapper)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
        }
        /// <summary>
        /// To Get List of Group
        /// </summary>
        /// <param name="userId">Provide current filtering, sorting and paging criteria</param>
        /// <returns>Returns object of type ItemDataReponse as Json result either as a success or failed response call</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<ItemDataReponse<List<UserGroupDto>>>> GetList([FromQuery] int userId)
        {
            var list = await this._repositroy.GetAll().Where(x=> x.UserId == userId).ToListAsync();

            var response = new ItemDataReponse<List<UserGroupDto>>
            {
                Success = true,
                Data = this._mapper.Map<List<UserGroupDto>>(list)
            };

            return Ok(response);
        }
    }
}
