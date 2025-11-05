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
       Task<IdentityResult> CreateRole(AdminCreateRoleViewModel adminCreateRoleViewModel);

        Task<bool> DeleteRole(string id);

        Task<bool> UpdateRole(AdminUpdateRoleViewModel adminUpdateRoleViewModel);

        IList<AppRole> GetAllRoles();
    }
}
