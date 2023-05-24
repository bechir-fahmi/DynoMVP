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

namespace Dyno.Platform.ReferentialData.Business.Services.UserDataService
{
    public class UserService : IUserService
    {

        public readonly IMapperSession<UserEntity> _mapperSession;
        public readonly IMapper _mapper;
        public readonly UserManager<UserEntity> _userManager;
        


        public UserService(IMapper mapper, UserManager<UserEntity> userManager, IMapperSession<UserEntity> mapperSession)

        {
            _mapperSession = mapperSession;
            _mapper = mapper;
            _userManager = userManager;




        }


        public List<UserDTO> GetAll()
        {
            List<UserEntity> userEntities = _userManager.Users.ToList();
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

        public async void Delete(string id)
        {
            var userEntity = await _userManager.FindByIdAsync(id);
            if (userEntity != null)
            {

                _userManager.DeleteAsync(userEntity);

            }

        }





        public async Task<UserDTO> GetByUserName(string name)
        {

            UserEntity userEntity = await _userManager.FindByNameAsync(name);
            User user = _mapper.Map<User>(userEntity);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task Update(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            UserEntity userEntity = _mapper.Map<UserEntity>(user);

            //_mapperSession.Update(userEntity);
            _userManager.UpdateAsync(userEntity);





        }

        public async Task<UserDTO> GetByEmail(string email)
        {

            UserEntity userEntity = await _userManager.FindByEmailAsync(email);
            User user = _mapper.Map<User>(userEntity);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }



        public async Task Create(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            var result = await _userManager.CreateAsync(userEntity, userDTO.PasswordHash);

        }


    }
}
