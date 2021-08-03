using AutoMapper;
using Chat.ApplicationService.Dtos;
using Chat.ApplicationService.Services.Auth;
using Chat.ApplicationService.Services.Message;
using Chat.Core.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repositroy;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public UserService(IUserRepository repositroy, IMapper mapper, IAuthService authService)
        {
            this._repositroy = repositroy;
            this._mapper = mapper;
            this._authService = authService;
        }
        public async Task<ItemReponse> Add(UserDto userDto)
        {
            var entity = this._mapper.Map<Chat.Core.Domains.User>(userDto);
            entity.Password = this._authService.HashPassword(userDto.Password);
            var user = this._repositroy.GetIQueryable().FirstOrDefault(x => x.UserName == userDto.UserName);
            var response = new ItemReponse();
            
            if (user != null)
            {
                response.Success = false;
                response.Error = "user name is duplicate";
            }
            else
            {
                await this._repositroy.AddAsync(entity);
                response.Success = true;
            }

            return response;
        }

        public async Task<ItemDataReponse<AuthData>> Login(UserDto userDto)
        {
            var response = new ItemDataReponse<AuthData>();

            var user = await _repositroy.GetIQueryable().FirstOrDefaultAsync(x => x.UserName == userDto.UserName);

            if(user == null)
            {
                response.Error = "UserName is Invalid";
                response.Success = false;
            }
            else
            {
                if(!this._authService.VerifyPassword(userDto.Password, user.Password))
                {
                    response.Error = "Password is Invalid";
                    response.Success = false;
                }
                else
                {
                    var authData = this._authService.GetAuthData(user.Id.ToString());
                    response.Data = authData;
                    response.Success = true;
                }
            }

            return response;

        }

        public async Task<ItemDataReponse<UserDto>> GetUserById(int userId)
        {
            var user = await this._repositroy.GetIQueryable().FirstOrDefaultAsync(x => x.Id == userId);

            if(user == null)
            {
                throw new Exception("Can not find User");
            }
            var response = new ItemDataReponse<UserDto>
            {
                Success = true,
                Data = this._mapper.Map<UserDto>(user)
            };

            return response;
        }

    }
}
