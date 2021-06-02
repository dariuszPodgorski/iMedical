using AutoMapper;
using iMedicalAPI.Models;
using iMedicalAPI.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Services
{
    public interface IPatientService
    {
        IEnumerable<PatientDto> GetAll();
        PatientDto GetById(int id);
    }

    public class PatientService : IPatientService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;

        public PatientService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PatientDto GetById(int id)
        {
            var patient = _dbContext
               .Patients
               .FirstOrDefault(r => r.IdPatient == id);

            if (patient is null)
            {
                return null;
            }

            var result = _mapper.Map<PatientDto>(patient);
            return result;
        }

        public IEnumerable<PatientDto> GetAll()
        {
            var patient = _dbContext
                .Patients
                .ToList();

            var patientsDtos = _mapper.Map<List<PatientDto>>(patient);

            return patientsDtos;
        }

    }
}
