using CoreSharp.NHibernate.PostgreSQL.Types;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.DTO.UserClaimData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        public readonly SignInManager<UserEntity> _signInManager;
        public readonly UserManager<UserEntity> _userManager;

        public AuthentificationService(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) 
        { 
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public void ForgetPassword()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(LoginModelDTO loginModelDTO)
        {
            UserEntity userEntity = await _userManager.FindByEmailAsync(loginModelDTO.Email);
            if(userEntity != null) 
            {
                bool result = await _userManager.CheckPasswordAsync(userEntity, loginModelDTO.Password);
                return result;
            }
            else { throw new NotImplementedException(); }
            
            

        }
    }
}
