using iMedicalAPI.Models.PatientModels;
using iMedicalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Controllers
{
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientDto>> GetAll()
        {

            var patientsDtos = _patientService.GetAll();


            return Ok(patientsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PatientDto> Get([FromRoute] int id)
        {
            var patientType = _patientService.GetById(id);

            if (patientType is null)
            {
                return NotFound();
            }

            return Ok(patientType);
        }
    }
}
