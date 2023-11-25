using Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService;
using Dyno.Platform.ReferentialData.Business.IServices.IBalanceDataService;
using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.DTO.BalanceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.BalanceData
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        public readonly IBalanceService _balanceService;
        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        [Route("GetAllBalances")]
        public IActionResult GetAllBalances()
        {
            IList<BalanceDTO> balanceDTOs  = _balanceService.GetAll();
            return Ok(balanceDTOs);
        }

        [HttpGet]
        [Route("GetBalanceByUserId/{userId}")]
        public IActionResult GetBalanceByUserId(string id)
        {
            IList<BalanceDTO> balanceDTOs = _balanceService.GetBalanceByUserId(id);
            return Ok(balanceDTOs);
        }

       
        [HttpPost]
        [Route("CreateBalance")]
        public IActionResult CreateBalance([FromBody] BalanceDTO balance)
        {
            _balanceService.Create(balance) ;
            return Ok();
        }

        [HttpPut]
        [Route("UpdateBalance")]
        public IActionResult UpdateBalance([FromBody] BalanceDTO balanceDTO)
        {
            _balanceService.Update(balanceDTO) ;
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBalance/{balanceId}")]
        public IActionResult DeleteBalance(Guid balanceId)
        {
            _balanceService.Delete(balanceId) ;
            return Ok();
        }
    }
}
