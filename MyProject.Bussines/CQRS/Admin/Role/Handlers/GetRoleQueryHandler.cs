using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Role.Queries.Request;
using MyProject.Bussines.CQRS.Admin.Role.Queries.Response;
using MyProject.Bussines.Services;
using MyProject.DTO.DTOs.AdminDTOs.RoleDto;

namespace MyProject.Bussines.CQRS.Admin.Role.Handlers
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQueryRequest, GetRoleQueryResponse>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
   
        public GetRoleQueryHandler(IRoleService roleService,
                                   IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
          
        }

        public Task<GetRoleQueryResponse> Handle(GetRoleQueryRequest request, CancellationToken cancellationToken)
        {
           
                var allRoleList = _roleService.GetAllRoles();
                var mappedAllRoleList = _mapper.Map<List<AppRoleDto>>(allRoleList);
                return Task.FromResult(new GetRoleQueryResponse
                {
                    RoleList = mappedAllRoleList,   
                });
           
        }
    }
}
