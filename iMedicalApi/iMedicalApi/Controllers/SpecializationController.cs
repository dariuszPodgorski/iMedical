using iMedicalApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iMedicalApi.Services;

namespace iMedicalApi.Controllers
{
    [Route("api/specialization")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }


        [HttpPost]
        public ActionResult CreateSpecialization([FromBody] CreateSpecializationDto dto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _specializationService.CreateSpecialization(dto);


            return Created("/api/specialization/{id}", null);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Specialization>> GetAll()
        {
            var specializations = _specializationService.GetAll();
            return Ok(specializations);
        }


        [HttpGet("{id}")]
        public ActionResult<SpecializationDto> Get([FromRoute] int id)
        {
            var specializations = _specializationService.GetById(id);

            if (specializations is null)
            {
                return NotFound();
            }

            return Ok(specializations);
        }

        
    }
}
