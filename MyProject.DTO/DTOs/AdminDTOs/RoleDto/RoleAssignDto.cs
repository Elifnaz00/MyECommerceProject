using MyProject.DTO.Models.AdminRoleViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.AdminDTOs.RoleDto
{
    public class RoleAssignDto
    {
        public string UserId { get; set; }
        public List<AdminRoleAssignViewModel> adminRoleAssignViewModels { get; set; }
    }  
        
}
