using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using LuftBornTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsRegisteredAsync(string entraObjectId)
        {
            var users = await _unitOfWork.Repository<User>().GetAllAsync();
            return users.Any(u => u.EntraObjectId == entraObjectId);
        }

        public async Task RegisterAsync(RegisterUserDto registerDto)
        {
            var repository = _unitOfWork.Repository<User>();
            var existing = await repository.GetAllAsync();

            if (existing.Any(u => u.EntraObjectId == registerDto.EntraObjectId))
            {
                return; // already registered — no-op, not an error
            }

            var user = new User
            {
                EntraObjectId = registerDto.EntraObjectId,
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName
            };

            await repository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
