using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.AdminDTOs.RoleDto;


namespace MyProject.Bussines.CQRS.Admin.Role.Queries.Response
{
    public class GetRoleQueryResponse
    {
        public List<AppRoleDto> RoleList { get; set; }
    }
}
