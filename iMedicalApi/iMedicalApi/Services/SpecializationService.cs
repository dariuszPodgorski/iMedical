using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iMedicalApi.Models;

namespace iMedicalApi.Services
{
    public class SpecializationService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;
        public SpecializationService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public SpecializationDto GetById(int id)
        {
            var specialization = _dbContext
                .Specializations
                .FirstOrDefault(p => p.IdSpecialization == id);

            if (specialization is null) return null;

            var result = _mapper.Map<SpecializationDto>(specialization);
                return result;
        }

        public IEnumerable<SpecializationDto> GetAll()
        {
            var specializations = _dbContext
              .Specializations
              .ToList();

            var specializationsDto = _mapper.Map<List<SpecializationDto>>(specializations);
            return specializationsDto;
        }

        public void CreateSpecialization(CreateSpecializationDto dto)
        {
            var specialization = _mapper.Map<Specialization>(dto);
            _dbContext.Specializations.Add(specialization);
            _dbContext.SaveChanges();


        }
    }
}
