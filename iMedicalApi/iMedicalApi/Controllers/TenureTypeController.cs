using iMedicalApi.Models;
using iMedicalApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Controllers
{
    [Route("api/tenureType")]
    public class TenureTypeController : ControllerBase
    {
        private readonly ITenureTypeService _tenureTypeService;
        public TenureTypeController(ITenureTypeService tenureTypeService)
        {
            _tenureTypeService = tenureTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TenureTypeDto>> GetAll()
        {

            var tenureTypesDtos = _tenureTypeService.GetAll();


            return Ok(tenureTypesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<TenureTypeDto> Get([FromRoute] int id)
        {
            var tenureType = _tenureTypeService.GetById(id);

            if (tenureType is null)
            {
                return NotFound();
            }

            return Ok(tenureType);
        }

        [HttpPost]
        public ActionResult CreateTenureType([FromBody] CreateTenureTypeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _tenureTypeService.Create(dto);


            return Created($"/api/tenureType/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _tenureTypeService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
