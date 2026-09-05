using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Domain.Entities
{
    public class User : BaseEntity
    {
        public string EntraObjectId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}
