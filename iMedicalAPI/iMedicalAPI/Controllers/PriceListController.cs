using iMedicalApi.Models;
using iMedicalApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedical.Controllers
{
    [Route("api/priceList")]
    [Authorize(Roles = "Administracja,Admin")]
    public class PriceListController : ControllerBase
    {
        private readonly IPriceListService _priceListService;
        public PriceListController(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PriceListDto>> GetAll()
        {

            var priceListsDtos = _priceListService.GetAll();


            return Ok(priceListsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PriceListDto> Get([FromRoute] int id)
        {
            var priceList = _priceListService.GetById(id);

            if (priceList is null)
            {
                return NotFound();
            }

            return Ok(priceList);
        }

        [HttpPost]
        public ActionResult CreatePriceList([FromBody] CreatePriceListDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _priceListService.Create(dto);


            return Created($"/api/priceList/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _priceListService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
