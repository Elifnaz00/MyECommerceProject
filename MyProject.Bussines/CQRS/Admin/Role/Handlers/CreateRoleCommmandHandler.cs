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
using MyProject.Bussines.Services;
using MyProject.DTO.Models.AdminRoleViewModel;

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
            try
            {
                    
                var mappedCreateRoleModel = _mapper.Map<AdminCreateRoleViewModel>(request);
                mappedCreateRoleModel.Id= Guid.NewGuid().ToString();
                await _roleService.CreateRole(mappedCreateRoleModel);
                return new CreateRoleCommmandResponse()
                {
                    Message = "Yeni rol başarıyla eklendi.",
                    StatusCode= 201 
                };

            }
            catch
            {
                return new CreateRoleCommmandResponse()
                {
                    Message = "Rol oluşturulurken bir hata oluştu!",
                    StatusCode = 500
                };
                //throw;
            }
        }
    }
}
