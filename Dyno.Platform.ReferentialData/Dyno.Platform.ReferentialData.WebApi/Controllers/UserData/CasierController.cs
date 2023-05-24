using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasierController : ControllerBase
    {

        private readonly ICasierService _casierService;
        private readonly ILogger<CasierController> _logger;


        public CasierController(ICasierService casierService, ILogger<CasierController> logger)
        {
            _casierService = casierService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllCasier")]

        public IActionResult GetAll()
        {
            IList<CasierDTO> casierDTOs = _casierService.GetAll();
            return Ok(casierDTOs);
        }

        [HttpPost]
        [Route("AddCasier")]
        public IActionResult Add([FromBody] CasierDTO casierDTO)
        {
            _casierService.Create(casierDTO);

            return Ok(casierDTO);

        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            CasierDTO casierDTO = _casierService.GetById(id);
            return Ok(casierDTO);
        }

        [HttpGet]
        [Route("GetCasierByUserName/{name}")]

        public async Task<IActionResult> GetByUserName(string name)
        {
            CasierDTO casierDTO = _casierService.GetByUserName(name);
            return Ok(casierDTO);
        }

        [HttpGet]
        [Route("GetCasierByEmail/{email}")]

        public async Task<IActionResult> GetByEmail(string email)
        {
            CasierDTO casierDTO = _casierService.GetByEmail(email);
            return Ok(casierDTO);
        }

        [HttpDelete]
        [Route("DeleteCasier/{id}")]
        public void Delete(Guid id)
        {
            _casierService.Delete(id);
        }

        [HttpPut]
        [Route("UpdateCasier")]

        public void Update([FromBody] CasierDTO casierDTO)
        {
            _casierService.Update(casierDTO);
        }


    }
}
