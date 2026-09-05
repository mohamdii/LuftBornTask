using LuftBornTask.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Commands
{
    internal class AddUserHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserService _userService;

        public AddUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.RegisterAsync(request.RegisterDto);
        }
    }
}
