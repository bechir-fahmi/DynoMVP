using Dyno.Platform.ReferentialData.DTO.UserClaimData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices
{
    public interface IAuthentificationService
    {
        Task<bool> Login(LoginModelDTO loginModelDTO);
        
        void ForgetPassword();
    }
}
