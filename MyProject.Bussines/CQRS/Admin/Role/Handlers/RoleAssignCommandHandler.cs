using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.Services;
using MyProject.DTO.Models.AdminRoleViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Role.Handlers
{
    public class RoleAssignCommandHandler : IRequestHandler<RoleAssignCommandRequest>
    {
        private readonly IRoleService _roleService;

        public RoleAssignCommandHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
           
        }

        public async Task<Unit> Handle(RoleAssignCommandRequest request, CancellationToken cancellationToken)
        {
            
            await _roleService.RoleAssignAsync(request.adminRoleAssignViewModels, request.UserId);
            return Unit.Value;
        }
    }
}
