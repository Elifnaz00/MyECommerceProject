using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Logging;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Response;
using MyProject.Bussines.Exceptions;
using MyProject.Bussines.Services;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.Entity.Enums;

namespace MyProject.Bussines.CQRS.Admin.Role.Handlers
{
    public class CreateRoleCommmandHandler : IRequestHandler<CreateRoleCommmandRequest, CreateRoleCommmandResponse>
    {
       
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public CreateRoleCommmandHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<CreateRoleCommmandResponse> Handle(CreateRoleCommmandRequest request, CancellationToken cancellationToken)
        {
          
            var mappedCreateRoleModel = _mapper.Map<AdminCreateRoleViewModel>(request);
                
            var identityResult = await _roleService.CreateRoleAsync(mappedCreateRoleModel);
            if(!identityResult.Succeeded)
            {
                throw new BadRequestException(identityResult.Errors.FirstOrDefault()?.Description ?? "Rol oluşturulamadı.");

            }

            return new CreateRoleCommmandResponse()
            {
                Message = "Yeni rol başarıyla eklendi.",
            };
        }
    }
}
