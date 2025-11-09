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
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var deleted = await _roleService.DeleteRoleAsync(request.Id);
                if(deleted == false)
                {
                    return new DeleteRoleCommandResponse
                    {
                        StatusCode = StatusCode.NotFound,
                        Message = "Silinmek istenilen rol bulunamadı!."
                    };
                }
                return new DeleteRoleCommandResponse
                {
                    StatusCode = StatusCode.Ok,
                    Message = "Rol silme işlemi başarılı!."
                };
            }
            catch
            {
                return new DeleteRoleCommandResponse
                {
                    StatusCode = StatusCode.InternalServerError,
                    Message ="Rol silinmeye çalışılırken hata oluştu!."
                };
            }
           
        }
    }
}
