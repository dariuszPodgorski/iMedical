using iMedical.Models.ContractModels;
using iMedicalApi.Models;
using iMedicalApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Controllers
{
    [Route("api/contractType")]
    public class ContractTypeController : ControllerBase
    {
        private readonly IContractTypeService _contractTypeService;
        public ContractTypeController(IContractTypeService contractTypeService)
        {
            _contractTypeService = contractTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContractTypeDto>> GetAll()
        {

            var contractTypesDtos = _contractTypeService.GetAll();


            return Ok(contractTypesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ContractTypeDto> Get([FromRoute] int id)
        {
            var contractType = _contractTypeService.GetById(id);

            if (contractType is null)
            {
                return NotFound();
            }

            return Ok(contractType);
        }

        [HttpPost]
        public ActionResult CreateContractType([FromBody] CreateContractTypeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _contractTypeService.Create(dto);


            return Created($"/api/contractType/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _contractTypeService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateContractTypeDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _contractTypeService.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
