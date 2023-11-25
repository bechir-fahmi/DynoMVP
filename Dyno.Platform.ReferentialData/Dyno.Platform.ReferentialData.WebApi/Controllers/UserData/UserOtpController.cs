using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platform.Shared.Enum;
using Platform.Shared.Result;
using System.Security.Claims;
using static NHibernate.Engine.Query.CallableParser;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.UserData
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserOtpController : ControllerBase
    {
        private readonly IUserOtpService _userOtpService;
        private readonly ILogger<UserOtpController> _logger;
        public UserOtpController(IUserOtpService userOtpService, 
            ILogger<UserOtpController> logger)
        {
            _userOtpService = userOtpService;
            _logger = logger;
        }

        [HttpGet]
        [Route("SendOTP/{phoneNumber}/{otpType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SendOTP(string phoneNumber, OtpType otpType)
        {
            try
            {
                var result = _userOtpService.GetOtpVerificationCode(phoneNumber, otpType);
                return Ok(result);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(SendOTP)}");
                return StatusCode(500, "Internal server Error. Please try later");
            }
            
        }

        [HttpGet]
        [Route("VerifyOTP/{newCode}/{phoneNumber}/{otpType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult VerifyOTP(string newCode ,string phoneNumber, OtpType otpType)
        {
            try
            {
                var result = _userOtpService.VerifierCode(newCode, phoneNumber, otpType);
                return Ok(result);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(VerifyOTP)}");
                return StatusCode(500, "Internal server Error. Please try later");
            }
            
        }
    }
}
