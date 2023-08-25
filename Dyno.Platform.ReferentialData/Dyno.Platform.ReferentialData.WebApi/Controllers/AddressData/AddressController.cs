using Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService;
using Dyno.Platform.ReferentialData.DTO.AddressData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.AddressData
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public readonly IAddressService _addressService;
        public AddressController(IAddressService addressService) 
        {
            _addressService = addressService;
        }

        [HttpGet]
        [Route("GetAllAddress")]
        public IActionResult GetAllAdress() 
        {
            IList<AddressDTO> addressDTOs = _addressService.GetAllAddresses();
            return Ok(addressDTOs);
        }

        [HttpGet]
        [Route("GetAddressByUserId/{userId}")]
        public IActionResult GetAdressByUserId(string userId)
        {
            IList<AddressDTO> addressDTOs = _addressService.GetAddressByUserId(userId);
            return Ok(addressDTOs);
        }

        [HttpGet]
        [Route("GetAddressByName/{addressName}")]
        public IActionResult GetAdressByName(string addressName)
        {
            AddressDTO addressDTOs = _addressService.GetAddressByName(addressName);
            return Ok(addressDTOs);
        }

        [HttpPost]
        [Route("CreateAddress")]
        public IActionResult CreateAdress([FromBody] AddressDTO addressDTO)
        {
             _addressService.CreateAddress(addressDTO);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateAddress")]
        public IActionResult UpdateAdress([FromBody] AddressDTO addressDTO)
        {
            _addressService.UpdateAddress(addressDTO);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAddress/{addressId}")]
        public IActionResult DeleteAdress( int addressId)
        {
            _addressService.DeleteAddress(addressId);
            return Ok();
        }
    }
}
