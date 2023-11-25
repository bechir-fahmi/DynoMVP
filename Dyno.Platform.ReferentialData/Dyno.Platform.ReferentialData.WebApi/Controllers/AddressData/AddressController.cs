using Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService;
using Dyno.Platform.ReferentialData.DTO.AddressData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platform.Shared.Result;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.AddressData
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IAddressService addressService,
            ILogger<AddressController> logger) 
        {
            _addressService = addressService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllAdress() 
        {
            try
            {
                List<AddressDTO> addressDTOs = _addressService.GetAll();
                return Ok(addressDTOs);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllAdress)}");
                return StatusCode(500, "Internal server Error. Please try later");
            }
            
        }

        [HttpGet]
        [Route("GetAddressByUserId/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAdressByUserId(string userId)
        {
            IList<AddressDTO> addressDTOs = _addressService.GetAddressByUserId(userId);
            return Ok(addressDTOs);
        }

        [HttpGet]
        [Route("GetAddressByName/{addressName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAdressByName(string addressName)
        {
            AddressDTO addressDTOs = _addressService.GetAddressByName(addressName);
            return Ok(addressDTOs);
        }

        [HttpPost]
        [Route("CreateAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAdress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                OperationResult<AddressDTO> result = _addressService.Create(addressDTO);
                return Ok(result);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateAdress)}");
                return StatusCode(500, "Internal server Error. Please try later");
            }
             
        }

        [HttpPut]
        [Route("UpdateAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateAdress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                OperationResult<AddressDTO> result = _addressService.Update(addressDTO);
                return Ok(result);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateAdress)}");
                return StatusCode(500, "Internal server Error. Please try later");
            }
            
        }

        [HttpDelete]
        [Route("DeleteAddress/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteAdress(Guid addressId)
        {
            try
            {
                OperationResult<AddressDTO> result = _addressService.Delete(addressId);
                return Ok(result);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteAdress)}");
                return StatusCode(500, "Internal server Error. Please try later");
            }
            
        }

       
    }
}
