using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Response;
using MyProject.Bussines.Exceptions;
using MyProject.Bussines.Services;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.Entity.Enums;

namespace MyProject.Bussines.CQRS.Admin.Role.Handlers
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            
                var mappedCreateRole = _mapper.Map<AdminUpdateRoleViewModel>(request);
                var isSuccess= await _roleService.UpdateRoleAsync(mappedCreateRole);
                if(isSuccess == false)
                {
                    throw new NotFoundException("aranan rol bulunamadı");
                }

                return new UpdateRoleCommandResponse
                {         
                    StatusCode = StatusCode.NoContent
                };
           
               
            
        }
    }
}
