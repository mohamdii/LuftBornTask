using LuftBornTask.API.Contracts;
using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Features.Commands;
using LuftBornTask.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuftBornTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<object>>> Register([FromBody] RegisterUserDto dto)
        {
            await _sender.Send(new AddUserCommand(dto));
            return Ok();
        }
    }
}
