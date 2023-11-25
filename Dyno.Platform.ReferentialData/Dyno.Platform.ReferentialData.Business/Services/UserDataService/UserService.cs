using AutoMapper;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using NHibernate;
using System.ComponentModel;
using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using Platform.Shared.Result;
using Platform.Shared.Enum;
using Platform.Shared.Mapper;

namespace Dyno.Platform.ReferentialData.Business.Services.UserDataService
{
    public class UserService : IUserService
    {

        public readonly IMapperSession<UserEntity> _mapperSession;
        public readonly IMapper _mapper;
        public readonly UserManager<UserEntity> _userManager;
        public readonly RoleManager<RoleEntity> _roleManager;
        


        public UserService(IMapper mapper, 
            UserManager<UserEntity> userManager, 
            IMapperSession<UserEntity> mapperSession, 
            RoleManager<RoleEntity> roleManager)
        {
            _mapperSession = mapperSession;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #region Get
        public List<UserDTO> GetAll()
        {
            List<UserEntity> userEntities = _userManager.Users.ToList();
            foreach(var user in userEntities)
            {
                foreach(var role in user.Roles) { role.Users = null; }
                foreach(var address in user.Addresses) { address.User = null; }
                
               
            }
            List<User> users = _mapper.Map<List<User>>(userEntities);
            List<UserDTO> userDTOs = _mapper.Map<List<UserDTO>>(users);
            return userDTOs;
        }

        public async Task<UserDTO> GetById(string id)
        {
            UserEntity userEntity = await _userManager.FindByIdAsync(id);
            User user = _mapper.Map<User>(userEntity);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
        
        public async Task<UserDTO> GetByUserName(string name)
        {

            UserEntity userEntity = await _userManager.FindByNameAsync(name);
            User user = _mapper.Map<User>(userEntity);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {

            UserEntity userEntity = await _userManager.FindByEmailAsync(email);
            User user = _mapper.Map<User>(userEntity);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        } 
        #endregion

        #region Create
        public async Task<OperationResult<UserDTO>> Create(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            if(userDTO.Roles != null && userDTO.Roles.Count > 0)
            {
                foreach (var entity in userDTO.Roles)
                {
                    RoleEntity? roleEntity = await _roleManager.FindByIdAsync(entity.Id);
                    if (roleEntity != null)
                    {
                        userEntity.Roles.Add(roleEntity);
                    }

                    return new OperationResult<UserDTO>
                    {
                        Result = QueryResult.IsFailed,
                        ExceptionMessage = "Role Unfound"
                    };
                }
            }
            if(userDTO.PasswordHash != null)
            {
                var result = await _userManager.CreateAsync(userEntity, userDTO.PasswordHash);
                if (result.Succeeded)
                    return new OperationResult<UserDTO>
                    {
                        Result = QueryResult.IsSucced,
                        ExceptionMessage = "User Added Successfully"
                    };
                return new OperationResult<UserDTO>
                {
                    Result = QueryResult.IsFailed,
                    ExceptionMessage = result.Errors.ToString()
                };

            }

            return new OperationResult<UserDTO>
            {
                Result = QueryResult.IsFailed,
                ExceptionMessage = "Empty Password"
            };
                
        }

        #endregion

        #region Update
        public async Task<OperationResult<UserDTO>> Update(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            var result = await _userManager.UpdateAsync(userEntity);
            if (result.Succeeded)
                return new OperationResult<UserDTO>
                {
                    Result = QueryResult.IsSucced,
                    ExceptionMessage = "User Updated Successfully"
                };
            return new OperationResult<UserDTO>
            {
                Result = QueryResult.IsFailed,
                ExceptionMessage = result.Errors.ToString()
            };
        }

        public async Task<OperationResult<UserDTO>> UpdateUserInfo(UpdateUserDTO update)
        {
            UserEntity? userEntity = await _userManager.FindByIdAsync(update.Id);
            if (userEntity != null)
            {
                userEntity.Email = update.Email;
                userEntity.PhoneNumber = update.PhoneNumber;
                var result = await _userManager.UpdateAsync(userEntity);
                return new OperationResult<UserDTO>
                {
                    Result = QueryResult.IsSucced,
                    ExceptionMessage = "User is Updated"
                };

            }
            return new OperationResult<UserDTO>
            {
                Result = QueryResult.UnAuthorized,
                ExceptionMessage = "User Unfound"
            };
        }

        public async Task<OperationResult<UserDTO>> UpdateUserPassword(UpdatePasswordDTO updatePassword)

        {
            UserEntity? userEntity = await _userManager.FindByIdAsync(updatePassword.Id);
            if (userEntity != null)
            {
                IdentityResult result = await _userManager.ChangePasswordAsync(userEntity, updatePassword.CurrentPassword, updatePassword.NewPassword);

                if (result.Succeeded)
                {

                    return new OperationResult<UserDTO>
                    {
                        Result = QueryResult.IsSucced,
                        ExceptionMessage = "Password Updated"
                    };
                }

                return new OperationResult<UserDTO>
                {
                    Result = QueryResult.IsFailed,
                    ExceptionMessage = "Current Password is wrong"
                };
            }

            return new OperationResult<UserDTO>
            {
                Result = QueryResult.UnAuthorized,
                ExceptionMessage = "User Unfound"
            };

        }
        #endregion

        #region Delete
        public async Task<OperationResult<UserDTO>> Delete(string id)
        {
            var userEntity = await _userManager.FindByIdAsync(id);
            if (userEntity != null)
            {
                var result = await _userManager.DeleteAsync(userEntity);
                if (result.Succeeded)
                {
                    return new OperationResult<UserDTO>
                    {
                        Result = QueryResult.IsSucced,
                        ExceptionMessage = "User Deleted Successfully "
                    };
                }

                return new OperationResult<UserDTO>
                {
                    Result = QueryResult.IsFailed,
                    ExceptionMessage = result.Errors.ToString()
                };
            }

            return new OperationResult<UserDTO>
            {
                Result = QueryResult.UnAuthorized,
                ExceptionMessage = "User Unfound"
            };

        }
        #endregion
    }
}
