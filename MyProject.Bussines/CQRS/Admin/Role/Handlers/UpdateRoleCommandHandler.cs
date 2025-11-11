using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Response;
using MyProject.Bussines.Exceptions;
using MyProject.Bussines.Services;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.Entity.Enums;

namespace MyProject.Bussines.CQRS.Admin.Role.Handlers
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, Unit>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedUpdateRole = _mapper.Map<AdminUpdateRoleViewModel>(request);
            var result= await _roleService.UpdateRoleAsync(mappedUpdateRole);
            if (!result.Succeeded)
                throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Rol güncellenemedi.");

            return Unit.Value; 
        }
    }
}
