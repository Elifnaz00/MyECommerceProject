using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Bussines.CQRS.Admin.User.Queries.Request;
using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.User.Handlers
{
    public class GetUsersWithRolesQueryHandler : IRequestHandler<GetUsersWithRolesQueryRequest, IList<UserWithRoleDto>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUsersWithRolesQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IList<UserWithRoleDto>> Handle(GetUsersWithRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();

            var result = new List<UserWithRoleDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserWithRoleDto
                {
                    UserId = user.Id,
                    NameSurname = user.NameSurname,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = roles.FirstOrDefault() ?? "User"
                });
            }

            return result;
        }
    }
}
