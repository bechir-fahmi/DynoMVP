using Dyno.Platform.ReferentialData.Business.IServices.IAuthentification;
using Dyno.Platform.ReferentialData.DTO.AuthDTO;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.Authentification
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        public readonly IAuthentificationService _authentificationService;
        public readonly ILogger<AuthentificationController> _logger;

        public AuthentificationController(ILogger<AuthentificationController> logger,
            IAuthentificationService authentificationService)
        {
            _logger = logger;
            _authentificationService = authentificationService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO modelDTO)
        {
            var result = await _authentificationService.Login(modelDTO);
            return Ok(result);
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDTO modelDTO) 
        {
            var result= await _authentificationService.Register(modelDTO);
            return Ok(result);
        }
        [HttpPost]
        [Route("SendOTP/{PhoneNumber}")]
        public IActionResult SendOTP(string phoneNumber)
        {
            var result = _authentificationService.GetOtpVerificationCode(phoneNumber);
            return Ok(result);
        }
    }
}
