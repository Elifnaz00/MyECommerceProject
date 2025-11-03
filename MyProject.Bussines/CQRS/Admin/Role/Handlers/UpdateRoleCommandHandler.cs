using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Response;
using MyProject.Bussines.Services;
using MyProject.DTO.Models.AdminRoleViewModel;

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
            try
            {
                var mappedCreateRole = _mapper.Map<AdminUpdateRoleViewModel>(request);
                await _roleService.UpdateRole(mappedCreateRole);
                return new UpdateRoleCommandResponse()
                {
                    Message = "Rol güncellemesi başarılı!",
                    StatusCode = 204
                };
            }
            catch
            {
                return new UpdateRoleCommandResponse()
                {
                    Message = "Rol güncellenirken bir hata oluştu!",
                    StatusCode = 500
                };
            }
        }
    }
}
