﻿using Chat.ApplicationService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Services.User
{
    public interface IUserService
    {
        Task<ItemReponse> Add(UserDto userDto);

        Task<ItemDataReponse<UserDto>> Login(UserDto userDto);
    }
}
