using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedicalApi.Services;
using iMedicalApi.Models;

namespace iMedicalApi.Controllers
{
    [Route("api/visitType")]
    public class VisitTypeController : ControllerBase
    {
        private readonly IVisitTypeService _visitTypeService;
        public VisitTypeController(IVisitTypeService visitTypeService)
        {
            _visitTypeService = visitTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisitTypeDto>> GetAll()
        {

            var visitTypesDtos = _visitTypeService.GetAll();


            return Ok(visitTypesDtos);
        }


        [HttpGet("{id}")]
        public ActionResult<VisitTypeDto> Get([FromRoute] int id)
        {
            var visitType = _visitTypeService.GetById(id);

            if (visitType is null)
            {
                return NotFound();
            }

            return Ok(visitType);
        }

        [HttpPost]
        public ActionResult CreateVisitType([FromBody] CreateVisitTypeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _visitTypeService.Create(dto);


            return Created($"/api/visitType/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _visitTypeService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }


    }
}
