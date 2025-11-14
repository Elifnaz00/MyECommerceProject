using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public interface IRoleService
    {
       Task<IdentityResult> CreateRoleAsync(AdminCreateRoleViewModel adminCreateRoleViewModel);

        Task DeleteRoleAsync(string id);

        Task<IdentityResult> UpdateRoleAsync(AdminUpdateRoleViewModel adminUpdateRoleViewModel);

        IList<AppRole> GetAllRoles();

        Task RoleAssignAsync(List<AdminRoleAssignViewModel> adminRoleAssignViewModel, string id);
    }
}
