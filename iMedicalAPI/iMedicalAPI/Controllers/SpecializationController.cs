using AutoMapper;
using iMedicalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Controllers
{
    [Route("api/specializations")]
    public class SpecializationController : ControllerBase
    {
        private readonly iMedicalContext _dbContext;
        private readonly IMapper _mapper;

        public SpecializationController(iMedicalContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Specjalizacja>> GetAll()
        {
            var specializations = _dbContext
                .Specjalizacjas
                .ToList();

           
            return Ok(specializations);
        }


        [HttpGet("{id}")]
        public ActionResult<Specjalizacja> Get([FromRoute] int id)
        {
            var specializations = _dbContext
                .Specjalizacjas
                .FirstOrDefault(p => p.IdSpecjalizacja == id);

            if (specializations is null)
            {
                return NotFound();
            }

            return Ok(specializations);
        }
    }
}
