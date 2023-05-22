using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.Business.Services;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly ILogger<EmployerController> _logger;


        public EmployerController(IEmployerService employerService, ILogger<EmployerController> logger)
        {
            _employerService = employerService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllEmployer")]

        public IActionResult GetAll()
        {
            IList<EmployerDTO> employerDTOs = _employerService.GetAll();
            return Ok(employerDTOs);
        }

        [HttpPost]
        [Route("AddEmployer")]
        public  IActionResult Add([FromBody] EmployerDTO employerDTO)
        {
             _employerService.Create(employerDTO);

            return Ok(employerDTO);

        }

        [HttpGet]
        [Route("GetEmployerById/{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            EmployerDTO employerDTO = _employerService.GetById(id);
            return Ok(employerDTO);
        }

        [HttpGet]
        [Route("GetEmployerByUserName/{name}")]

        public async Task<IActionResult> GetByUserName(string name)
        {
            EmployerDTO employerDTO = _employerService.GetByUserName(name);
            return Ok(employerDTO);
        }

        [HttpGet]
        [Route("GetEmployerByEmail/{email}")]

        public async Task<IActionResult> GetByEmail(string email)
        {
            EmployerDTO employerDTO = _employerService.GetByEmail(email);
            return Ok(employerDTO);
        }

        [HttpDelete]
        [Route("DeleteEmployer/{id}")]
        public void Delete(Guid id)
        {
            _employerService.Delete(id);
        }


        [HttpPut]
        [Route("UpdateEmployer")]
        public void Update(EmployerDTO employerDTO)
        {
            _employerService.Update(employerDTO);
        }
    }
}
