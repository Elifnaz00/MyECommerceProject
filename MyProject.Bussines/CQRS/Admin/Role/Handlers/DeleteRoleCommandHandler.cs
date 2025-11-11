using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Response;
using MyProject.Bussines.Services;
using MyProject.Entity.Enums;

namespace MyProject.Bussines.CQRS.Admin.Role.Handlers
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest>
    {
        private readonly IRoleService _roleService;
        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Unit> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _roleService.DeleteRoleAsync(request.Id);
            return Unit.Value;

        }
    }
 }

