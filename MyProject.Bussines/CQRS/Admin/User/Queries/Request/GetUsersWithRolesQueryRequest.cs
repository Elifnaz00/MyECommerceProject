using MediatR;
using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.User.Queries.Request
{
    public class GetUsersWithRolesQueryRequest : IRequest<IList<UserWithRoleDto>>
    {

    }
}
