

using Chat.ApplicationService.Dtos;
using Chat.ApplicationService.Services.UserGroup;
using Chat.Core.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("usergroups")]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupSevice _service;
        public UserGroupController(IUserGroupSevice service)
        {
            this._service = service;
        }
        /// <summary>
        /// To Get List of Group
        /// </summary>
        /// <param name="userId">Provide current filtering, sorting and paging criteria</param>
        /// <returns>Returns object of type ItemDataReponse as Json result either as a success or failed response call</returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("{userId}/getlistbyuserid")]
        public async Task<ActionResult<ItemDataReponse<List<UserGroupDto>>>> GetList(int userId)
        {
            var response = await this._service.GetList(userId);

            return Ok(response);
        }
    }
}
