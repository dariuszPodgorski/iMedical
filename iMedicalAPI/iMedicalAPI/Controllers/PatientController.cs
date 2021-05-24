using iMedicalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Controllers
{
    [Route("api/pacjent")]
    public class PatientController : ControllerBase
    {
        private readonly iMedicalContext _dbContext;

        public PatientController(iMedicalContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pacjent>>GetAll()
        {
            var patients = _dbContext
                .Pacjents
                .ToList();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public ActionResult<Pacjent>Get([FromRoute] int id)
        {
            var patients = _dbContext
                .Pacjents
                .FirstOrDefault(p => p.IdPacjent == id );

            if(patients is null)
            {
                return NotFound();
            }

            return Ok(patients);
        }
        
    }
}
