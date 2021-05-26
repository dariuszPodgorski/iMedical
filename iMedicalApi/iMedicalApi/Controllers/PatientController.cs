using AutoMapper;
using iMedicalApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace iMedicalApi.Controllers
{
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;
        public PatientController(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientDto>> GetAllPatient()
        {
            var patients = _dbContext
                .Patients
                .ToList();

            var patientsDtos = _mapper.Map <List<PatientDto>>(patients);


            return Ok(patientsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PatientDto> Get([FromRoute] int id)
        {
            var Patient = _dbContext
                .Patients
                .FirstOrDefault(p => p.IdPatient == id);

            if (Patient is null)
            {
                return NotFound();
            }
            var patientsDtos = _mapper.Map<PatientDto>(Patient);
            return Ok(patientsDtos);
        }

        [HttpPost]
        public ActionResult CreatePatient([FromBody]CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();

            return Created("/api/patient/{patient.id}",null);
        }
    }
}
