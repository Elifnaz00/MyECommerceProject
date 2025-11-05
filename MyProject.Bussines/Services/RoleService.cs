using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly IMapper _mapper;

    public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateRole(AdminCreateRoleViewModel adminCreateRoleViewModel)
        {
            
            var hasValue= await _roleManager.FindByNameAsync(adminCreateRoleViewModel.Name);
            var mappedAppRoleValue = _mapper.Map<AppRole>(hasValue);
            if (hasValue != null)
            {
                await _roleManager.UpdateAsync(mappedAppRoleValue);
            }
            return await _roleManager.CreateAsync(mappedAppRoleValue); 
        }


        public async Task<bool> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null)
                return false;
            IdentityResult identityResult = await _roleManager.DeleteAsync(role);
            return identityResult.Succeeded;
        }


        public async  Task<bool> UpdateRole(AdminUpdateRoleViewModel adminUpdateRoleViewModel)
        {
            var role= await _roleManager.FindByIdAsync(adminUpdateRoleViewModel.Id);
            if (role is null)
                return false;

            role.Name = adminUpdateRoleViewModel.Name;
            IdentityResult identityResult = await _roleManager.UpdateAsync(role);
            return identityResult.Succeeded;

        }

        public IList<AppRole> GetAllRoles() {
            return _roleManager.Roles.ToList();
        } 
    }
    
    
}
