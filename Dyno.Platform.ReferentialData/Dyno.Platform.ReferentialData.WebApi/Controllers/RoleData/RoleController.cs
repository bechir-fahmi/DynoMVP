﻿using Dyno.Platform.ReferentialData.Business.IServices.IRoleDataService;
using Dyno.Platform.ReferentialData.DTO.RoleData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platform.Shared.Result;

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
        public IActionResult GetAll()
        {
            IList<RoleDTO> roleDTOs = _roleService.GetAll();
            return Ok(roleDTOs);
        }

        [HttpGet]
        [Route("GetRoleById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            RoleDTO roleDTO = await _roleService.GetById(id);
            return Ok(roleDTO);
        }

        [HttpGet]
        [Route("GetRoleByName/{name}")]

        public async Task<IActionResult> GetByName(string name)
        {
            RoleDTO roleDTO = await _roleService.GetByName(name);
            return Ok(roleDTO);
        }

        [HttpPost]
        [Route("CreateRole")]
        [ProducesResponseType(typeof(OperationResult<RoleDTO>), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] RoleDTO roleDTO)
        {
            try
            {
                OperationResult<RoleDTO> result = await _roleService.Create(roleDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"----Something went wrong in the {nameof(Create)}");
                return StatusCode(500, "Internal Server Error, please try later!");
            }

        }



        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public void DeleteById(string id)
        {
            _roleService.Delete(id);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task Update([FromBody] RoleDTO roleDTO)
        {
            await _roleService.Update(roleDTO);

        }

        //[HttpGet]
        //[Route("GetRole")]

        //public async Task<IActionResult> GetByName()
        //{
        //    RoleDTO roleDTO = await _roleService
        //    return Ok(roleDTO);
        //}



    }
}
