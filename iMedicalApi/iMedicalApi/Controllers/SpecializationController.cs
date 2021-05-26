using iMedicalApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace iMedicalApi.Controllers
{
    [Route("api/specialization")]
    public class SpecializationController : ControllerBase
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper; 

        public SpecializationController(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Specialization>> GetAll()
        {
            var specializations = _dbContext
                .Specializations
                .ToList();


            return Ok(specializations);
        }


        [HttpGet("{id}")]
        public ActionResult<Specialization> Get([FromRoute] int id)
        {
            var specializations = _dbContext
                .Specializations
                .FirstOrDefault(p => p.IdSpecialization == id);

            if (specializations is null)
            {
                return NotFound();
            }

            return Ok(specializations);
        }

        [HttpPost]
        public ActionResult CreateSpecialization([FromBody] CreateSpecializationDto dto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specialization = _mapper.Map<Specialization>(dto);
            _dbContext.Specializations.Add(specialization);
            _dbContext.SaveChanges();

            return Created("/api/specialization/{specialization.id}", null);
        }
    }
}
