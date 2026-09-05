using LuftBornTask.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDto registerDto);
        Task<bool> IsRegisteredAsync(string entraObjectId);
    }
}
