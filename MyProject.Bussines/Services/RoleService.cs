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
            if(hasValue != null)
            {
                var updateMappedValue= _mapper.Map(adminCreateRoleViewModel, hasValue);
                await _roleManager.UpdateAsync(updateMappedValue);
            }
            return await _roleManager.CreateAsync(new AppRole
                {
                Id = adminCreateRoleViewModel.Id,           
                Name = adminCreateRoleViewModel.Name
                });
            
            
        }
        public async Task<IdentityResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null)
                throw new Exception("Role bulunamadı");
            return await _roleManager.DeleteAsync(role);
        }

        public async  Task<IdentityResult> UpdateRole(AdminUpdateRoleViewModel adminUpdateRoleViewModel)
        {
            var role= await _roleManager.FindByIdAsync(adminUpdateRoleViewModel.Id);
            if(role == null)
                throw new Exception("Role bulunamadı");
            role.Name = adminUpdateRoleViewModel.Name;
            return await _roleManager.UpdateAsync(role);

        }

        public IList<AppRole> GetAllRoles() {
            return _roleManager.Roles.ToList();
        } 
    }
    
    
}
