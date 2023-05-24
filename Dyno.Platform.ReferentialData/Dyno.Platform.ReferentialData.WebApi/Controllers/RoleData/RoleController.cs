using Dyno.Platform.ReferentialData.Business.IServices.IRoleDataService;
using Dyno.Platform.ReferentialData.DTO.RoleData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.RoleData
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly IRoleService _roleService;
        public readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService) 
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllRole")]
        public  IActionResult GetAll() 
        {
           IList<RoleDTO> roleDTOs =  _roleService.GetAll();
            return Ok(roleDTOs);
        }

        [HttpGet]
        [Route("GetRoleById/{id}")]
        public async Task<IActionResult> GetById(string id) 
        {
            RoleDTO roleDTO = await _roleService.GetById(id);
            return Ok(roleDTO);
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task create([FromBody] RoleDTO roleDTO) 
        {
           await _roleService.Create(roleDTO);
        }

        [HttpGet]
        [Route("GetRoleByName/{name}")]

        public async Task<IActionResult> GetByName(string name) 
        {
            RoleDTO roleDTO = await _roleService.GetByName(name);
            return Ok(roleDTO);
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public void DeleteById(string id) 
        {
           _roleService.Delete(id);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public  async Task Update([FromBody] RoleDTO roleDTO) 
        {
             await _roleService.Update(roleDTO);
            
        }
    }
}
