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
        private readonly ISpecializationService _specilizationService;
        public SpecializationController(ISpecializationService specializationService)
        {
            _specilizationService = specializationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SpecializationDto>> GetAll()
        {

            var specializationsDtos = _specilizationService.GetAll();


            return Ok(specializationsDtos);
        }


        [HttpGet("{id}")]
        public ActionResult<SpecializationDto> Get([FromRoute] int id)
        {
            var specialization = _specilizationService.GetById(id);

            if (specialization is null)
            {
                return NotFound();
            }

            return Ok(specialization);
        }

        [HttpPost]
        public ActionResult CreateSpecialization([FromBody] CreateSpecializationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _specilizationService.Create(dto);


            return Created($"/api/specialization/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _specilizationService.Delete(id);

            if(isDeleted )
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
