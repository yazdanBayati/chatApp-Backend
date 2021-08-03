using Chat.ApplicationService.Dtos;
using Chat.ApplicationService.Services.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("groups")]
    [Authorize]
    public class GroupController : ControllerBase
    {

        private readonly IGroupService _service;
        public GroupController(IGroupService service)
        {
            this._service = service;
        }

        ///// <summary>
        ///// To Add new Group of entity Model.
        ///// </summary>
        ///// <param name="ChatGroupDto">Requies parameter of required entity Model</param>
        ///// <returns>Returns object of type Reponse as Json result as a success or failed response</returns>
        //[HttpPost]
        //[Produces("application/json")]
        //public async Task<ActionResult<ItemReponse>> Add([FromBody] ChatGroupDto requestDto)
        //{
        //    var response = this._service.Add(requestDto);
        //    return Ok(response);
        //}

        /// <summary>
        /// To Get List of Group
        /// </summary>
        /// <returns>Returns object of type ItemDataReponse as Json result either as a success or failed response call</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<ItemDataReponse<List<ChatGroupDto>>>> GetList()
        {
            var response = await this._service.GetAll();
            return Ok(response);
        }
    }
}
