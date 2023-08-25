﻿using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices.IRoleDataService;
using Dyno.Platform.ReferentialData.BusinessModel.UserRole;
using Dyno.Platform.ReferentialData.DTO.RoleData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using Microsoft.AspNetCore.Identity;
using Platform.Shared.Enum;
using Platform.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services.RoleDataService
{
    public class RoleService : IRoleService
    {
        public readonly IMapper _mapper;
        public readonly RoleManager<RoleEntity> _roleManager;
        public readonly UserManager<UserEntity> _userManager;

        public RoleService(IMapper mapper, 
            RoleManager<RoleEntity> roleManager, 
            UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<OperationResult> Create(RoleDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            role.Id = Guid.NewGuid().ToString();
            role.ConcurrencyStamp = DateTime.Now.ToString();
            RoleEntity roleEntity = _mapper.Map<RoleEntity>(role);
            var result =await _roleManager.CreateAsync(roleEntity);
            return new OperationResult
            {
                Result = result.Succeeded ? QueryResult.IsSucceded : QueryResult.IsFailed,
                ExceptionMessage = !result.Succeeded ? result.Errors.ToList()[0].Description : "Role created successfully"
            };        
        }

        public async Task Delete(string id)
        {
            
            RoleEntity roleEntity = await _roleManager.FindByIdAsync(id);
            _roleManager.DeleteAsync(roleEntity);

        }

        public IList<RoleDTO> GetAll()
        {
            IList<RoleEntity> roleEntities = _roleManager.Roles.ToList();
            foreach (var role in roleEntities)
            {
                foreach (var user in role.Users) { user.Roles = null; }

            }
            IList<Role> roles = _mapper.Map<IList<Role>>(roleEntities);
            IList<RoleDTO> roleDTOs=_mapper.Map<IList<RoleDTO>>(roles);
            return roleDTOs;
        }

        public async Task<RoleDTO> GetById(string id)
        {
            RoleEntity roleEntity = await _roleManager.FindByIdAsync(id);
            Role role = _mapper.Map<Role>(roleEntity);
            RoleDTO roleDTO= _mapper.Map<RoleDTO>(role);    
            return roleDTO;
        }

        public async Task<RoleDTO> GetByName(string name)
        {
            RoleEntity roleEntity= await _roleManager.FindByNameAsync(name);
            Role role = _mapper.Map<Role>(roleEntity);
            RoleDTO roleDTO = _mapper.Map<RoleDTO>(role);
            return roleDTO;
        }

        public async Task Update(RoleDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            RoleEntity roleEntity = _mapper.Map<RoleEntity>(role);
           var result = await _roleManager.UpdateAsync(roleEntity);
        }
    }
}
