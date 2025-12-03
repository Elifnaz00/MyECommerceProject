using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.User.Queries.Response
{
    public class GetCustomerResponse
    {
        public IList<UserListDto> CustomerList { get; set; } = new List<UserListDto>();
       
    }
}
