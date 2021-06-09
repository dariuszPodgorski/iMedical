using iMedicalApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iMedicalApi.Services;
using iMedical.Models;
using Microsoft.AspNetCore.Authorization;

namespace iMedicalApi.Controllers
{
    [Route("api/specialization")]
    [ApiController]
    /*[Authorize(Roles = "Administracja,Admin")] */

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

            

            return Ok(specialization);
        }

        [HttpPost]
        public ActionResult CreateSpecialization([FromBody] CreateSpecializationDto dto)
        {
          

            var id = _specilizationService.Create(dto);


            return Created($"/api/specialization/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _specilizationService.Delete(id);

         

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateSpecializationDto dto, [FromRoute]int id)
        {
            
            _specilizationService.Update(id, dto);

          
            return Ok();
        }
    }
}
