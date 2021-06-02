using iMedicalAPI.Models.EmployeeModels;
using iMedicalAPI.Models.RegisterUserModels;
using iMedicalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("register")]
        public ActionResult RegisterEmployee([FromBody] RegisterEmployeeDto dto)
        {
            _employeeService.RegisterEmployee(dto);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll()
        {

            var employeesDtos = _employeeService.GetAll();


            return Ok(employeesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get([FromRoute] int id)
        {
            var employeeType = _employeeService.GetById(id);

            if (employeeType is null)
            {
                return NotFound();
            }

            return Ok(employeeType);
        }
    }
}
