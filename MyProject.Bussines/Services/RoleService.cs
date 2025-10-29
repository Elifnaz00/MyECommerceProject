using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<IdentityResult> CreateRole(AdminCreateRoleViewModel adminCreateRoleViewModel)
        {
            return _roleManager.CreateAsync(new AppRole
            {
                Name = adminCreateRoleViewModel.Name
            });
        }

        public async Task<IdentityResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return await _roleManager.DeleteAsync(role);
        }

        public async  Task<IdentityResult> UpdateRole(string id, string roleName)
        {
            var role= await _roleManager.FindByIdAsync(id);
            role.Name = roleName;
            return await _roleManager.UpdateAsync(role);

        }

        public IList<AppRole> GetAllRoles() {
            return _roleManager.Roles.ToList();
        } 
    }
    
    
}
