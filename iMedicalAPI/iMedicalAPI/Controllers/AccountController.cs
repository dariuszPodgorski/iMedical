using iMedicalAPI.Models;
using iMedicalAPI.Models.RegisterUserModels;
using iMedicalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("registerPatient")]
       public ActionResult RegisterPatient([FromBody] RegisterPatientDto dto)
        {
            _accountService.RegisterPatient(dto);
            return Ok();
        }

       

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);

        }
        
    }
}
