using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.DTO.UserClaimData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        public readonly IAuthentificationService _authentificationService;
        public readonly ILogger<AuthentificationController> _logger;

        public AuthentificationController(ILogger<AuthentificationController> logger, IAuthentificationService authentificationService) 
        {
            _logger = logger;
            _authentificationService = authentificationService;
        }

        [HttpPost]
        [Route("Login")]
        public Task Login ([FromBody] LoginModelDTO modelDTO)
        {
            
            return _authentificationService.Login(modelDTO);
        }
    }
}
