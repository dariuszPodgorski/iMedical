using iMedicalAPI.Models.PatientModels;
using iMedicalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Controllers
{
    [Route("api/patient")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {

            var usersDtos = _userService.GetAll();


            return Ok(usersDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> Get([FromRoute] int id)
        {
            var userType = _userService.GetById(id);

            if (userType is null)
            {
                return NotFound();
            }

            return Ok(userType);
        }
    }
}
