using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperUserController : ControllerBase
    {
        private readonly ISuperUserService _superUserService;
        private readonly ILogger<SuperUserController> _logger;


        public SuperUserController(ISuperUserService superUserService, ILogger<SuperUserController> logger)
        {
           _superUserService = superUserService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllSuperUser")]

        public IActionResult GetAll()
        {
            IList<SuperUserDTO> superUserDTOs = _superUserService.GetAll();
            return Ok(superUserDTOs);
        }

        [HttpPost]
        [Route("AddSuperUser")]
        public IActionResult Add([FromBody] SuperUserDTO superUserDTO)
        {
            _superUserService.Create(superUserDTO);

            return Ok(superUserDTO);

        }

        [HttpGet]
        [Route("GetSuperUserById/{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            SuperUserDTO superUserDTO = _superUserService.GetById(id);
            return Ok(superUserDTO);
        }

        [HttpGet]
        [Route("GetSuperUserByUserName/{name}")]

        public async Task<IActionResult> GetByUserName(string name)
        {
            SuperUserDTO superUserDTO  = _superUserService.GetByUserName(name);
            return Ok(superUserDTO);
        }

        [HttpGet]
        [Route("GetSuperUserByEmail/{email}")]

        public async Task<IActionResult> GetByEmail(string email)
        {
            SuperUserDTO superUserDTO = _superUserService.GetByEmail(email);
            return Ok(superUserDTO);
        }

        [HttpDelete]
        [Route("DeleteSuperUser/{id}")]
        public void Delete(Guid id)
        {
            _superUserService.Delete(id);
        }

        [HttpPut]
        [Route("UpdateSuperUser")]
        public void Update([FromBody] SuperUserDTO superUserDTO)
        {
            _superUserService.Update(superUserDTO);
        }
    }
}

