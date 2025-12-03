using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Bussines.CQRS.Admin.User.Queries.Request;
using MyProject.Bussines.CQRS.Admin.User.Queries.Response;
using MyProject.Bussines.Exceptions;
using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.User.Handlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerRequest, IList<UserListDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IList<UserListDto>> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customerList= await _userManager.GetUsersInRoleAsync("user");
            return _mapper.Map<IList<UserListDto>>(customerList);

        }
    }
}
