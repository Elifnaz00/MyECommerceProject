using MediatR;
using MyProject.DTO.DTOs.AdminDTOs.RoleDto;
using MyProject.DTO.Models.AdminRoleViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Role.Commands.Request
{
    public class RoleAssignCommandRequest: IRequest
    {

        public string UserId { get; set; }
        public List<AdminRoleAssignViewModel> adminRoleAssignViewModels { get; set; }
    }
}
