using MediatR;
using MyProject.Bussines.CQRS.Admin.User.Queries.Response;
using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.User.Queries.Request
{
    public class GetCustomerRequest : IRequest<IList<UserListDto>>
    {
    }
}
