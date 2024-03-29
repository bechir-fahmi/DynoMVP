﻿using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;


        public UserController(IUserService userService,ILogger<UserController> logger)
        {
            _userService = userService; 
            _logger = logger; 
        }

        [HttpGet]
        [Route("GetAllUser")]

        public IActionResult GetAll()
        {
            List<UserDTO> userDTOs = _userService.GetAll();
            return Ok(userDTOs);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            UserDTO userDTO = await _userService.GetById(id);
            return Ok(userDTO);
        }

        [HttpGet]
        [Route("GetByUserName/{name}")]

        public async Task<IActionResult> GetByUserName(string name)
        {
            UserDTO userDTO = await _userService.GetByUserName(name);
            return Ok(userDTO);
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]

        public async Task<IActionResult> GetByEmail(string email)
        {
            UserDTO userDTO = await  _userService.GetByEmail(email);
            return Ok(userDTO);
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public void Delete( string id)
        {
            _userService.Delete(id);
        }
       [HttpPost]
       [Route("AddUser")]

        public async Task Add([FromBody] UserDTO userDTO)
        {
              await _userService.Create(userDTO);
            

            
        }



    }
}
