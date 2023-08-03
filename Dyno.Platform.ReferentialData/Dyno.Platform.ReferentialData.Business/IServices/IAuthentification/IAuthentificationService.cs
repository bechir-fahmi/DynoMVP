using Dyno.Platform.ReferentialData.DTO.AuthDTO;
using Microsoft.AspNetCore.Identity;
using Platform.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace Dyno.Platform.ReferentialData.Business.IServices.IAuthentification
{
    public interface IAuthentificationService
    {
        Task<OperationResult> Login(LoginModelDTO loginModel);
        Task<OperationResult> Register(RegisterModelDTO register);

        MessageResource GetOtpVerificationCode (string phoneNumber);
        Task GetPassword(string password);
    }
}
