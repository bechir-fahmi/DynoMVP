﻿using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.Business.Services;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;


        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllEmployee")]

        public IActionResult GetAll()
        {
            IList<EmployeeDTO> employeeDTOs = _employeeService.GetAll();
            return Ok(employeeDTOs);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Add([FromBody] EmployeeDTO employeeDTO)
        {
            _employeeService.Create(employeeDTO);

            return Ok(employeeDTO);

        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            EmployeeDTO employeeDTO =  _employeeService.GetById(id);
            return Ok(employeeDTO);
        }

        [HttpGet]
        [Route("GetEmployeeByUserName/{name}")]

        public async Task<IActionResult> GetByUserName(string name)
        {
            EmployeeDTO employeeDTO =  _employeeService.GetByUserName(name);
            return Ok(employeeDTO);
        }

        [HttpGet]
        [Route("GetEmployeeByEmail/{email}")]

        public async Task<IActionResult> GetByEmail(string email)
        {
            EmployeeDTO employeeDTO = _employeeService.GetByEmail(email);
            return Ok(employeeDTO);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public void Delete(Guid id)
        {
            _employeeService.Delete(id);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public void Update([FromBody] EmployeeDTO employeeDTO) 
        {
            _employeeService.Update(employeeDTO);
        }
    }
}
