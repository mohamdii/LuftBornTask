using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.DTOs
{
    public class RegisterUserDto
    {
        public string EntraObjectId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
}
