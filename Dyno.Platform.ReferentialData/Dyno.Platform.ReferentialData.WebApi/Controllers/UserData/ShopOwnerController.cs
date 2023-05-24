using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopOwnerController : ControllerBase
    {
        private readonly IShopOwnerService _shopOwnerService;
        private readonly ILogger<ShopOwnerController> _logger;

        public ShopOwnerController(IShopOwnerService shopOwnerService, ILogger<ShopOwnerController> logger)
        {
            _shopOwnerService = shopOwnerService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllShopOwner")]
        public IActionResult GetAll()
        {
            IList<ShopOwnerDTO> shopOwnerDTOs = _shopOwnerService.GetAll();
            return Ok(shopOwnerDTOs);
        }

        [HttpGet]
        [Route("GetShopOwnerById/{id}")]
        public IActionResult GetById(Guid id) 
        {
            ShopOwnerDTO shopOwnerDTO= _shopOwnerService.GetById(id);
            return Ok(shopOwnerDTO);
        }

        [HttpGet]
        [Route("GetShopOwnerByUserName/{name}")]

        public IActionResult GetByName(string name)
        {
            ShopOwnerDTO shopOwnerDTO =_shopOwnerService.GetByUserName(name);
            return Ok(shopOwnerDTO);
        }

        [HttpGet]
        [Route("GetShopOwnerByEmail/{email}")]

        public IActionResult GetByEmail(string email) 
        {
            ShopOwnerDTO shopOwnerDTO=_shopOwnerService.GetByEmail(email);
            return Ok(shopOwnerDTO);
        }

        [HttpPost]
        [Route("AddShopOwner")]
        public IActionResult Create([FromBody] ShopOwnerDTO shopOwnerDTO)
        {
            _shopOwnerService.Create(shopOwnerDTO);

            return Ok(shopOwnerDTO);

        }


        [HttpDelete]
        [Route("DeleteShopowner/{id}")]
        public void DeleteById(Guid id) 
        {

            _shopOwnerService.Delete(id);
        
        }

        [HttpPut]
        [Route("UpdateShopOwner")]
        public void Update([FromBody] ShopOwnerDTO shopOwnerDTO) 
        {
            _shopOwnerService.Update(shopOwnerDTO);
        }



    }
}
