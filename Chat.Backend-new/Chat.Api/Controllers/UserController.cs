using AutoMapper;
using Chat.ApplicationService.Dtos;
using Chat.ApplicationService.Services.Auth;
using Chat.ApplicationService.Services.User;
using Chat.Core.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            this._service = service;
        }

        // <summary>
        // Register New User
        // </summary>
        // <param name = "requestDto" > Requies parameter of required entity Model</param>
        // <returns>Returns object of type Reponse as Json result as a success or failed response</returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("register")]
        public async Task<ActionResult<ItemReponse>> Register([FromBody] UserDto requestDto)
        {
            var response = await this._service.Add(requestDto);
            return Ok(response);
        }


        // <summary>
        // Login
        // </summary>
        // <param name = "requestDto" > Requies parameter of required entity Model</param>
        // <returns>Returns object of type Reponse as Json result as a success or failed response</returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("login")]
        public async Task<ActionResult<ItemDataReponse<AuthData>>> Login([FromBody] UserDto requestDto)
        {
            var response = await this._service.Login(requestDto);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("{userId}/getuserbyid")]
        public async Task<ActionResult<ItemDataReponse<UserDto>>> GetUserById(int userId)
        {
            var response = await this._service.GetUserById(userId);

            return Ok(response);
        }
    }
}
