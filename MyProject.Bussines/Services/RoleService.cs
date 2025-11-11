using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Bussines.Exceptions;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;
    

    public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateRoleAsync(AdminCreateRoleViewModel adminCreateRoleViewModel)
        {
            
            var hasValue= await _roleManager.FindByNameAsync(adminCreateRoleViewModel.Name);
            
            if (hasValue is not null)
            {
                hasValue.Name = adminCreateRoleViewModel.Name;
                return await _roleManager.UpdateAsync(hasValue);
            }
       
            return await _roleManager.CreateAsync(new AppRole
            {
                Name = adminCreateRoleViewModel.Name          
            }); 
        }


        public async Task DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null)
                throw new NotFoundException("Aranan veri bulunamadı.");

            await _roleManager.DeleteAsync(role);
        }
    

        public IList<AppRole> GetAllRoles() {
            return _roleManager.Roles.ToList();
        }



        public async Task<IdentityResult> UpdateRoleAsync(AdminUpdateRoleViewModel adminUpdateRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(adminUpdateRoleViewModel.Id);
            if (role is null)
                throw new NotFoundException("Aranan veri bulunamadı.");

            role.Name = adminUpdateRoleViewModel.Name;
            return await _roleManager.UpdateAsync(role);
            
        }
    }
    
    
}
