using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.AdminDTOs.UserDto
{
    public class UserWithRoleDto
    {
        public string UserId { get; set; }
        public string? NameSurname { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; } 
    }
}
