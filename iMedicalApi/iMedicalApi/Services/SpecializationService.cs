using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iMedicalApi.Models;

namespace iMedicalApi.Services
{
    public interface ISpecializationService
    {
        int CreateSpecialization(CreateSpecializationDto dto);
        IEnumerable<Specialization> GetAll();
        SpecializationDto GetById(int id);
    }

    public class SpecializationService : ISpecializationService
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

        public IEnumerable<Specialization> GetAll()
        {
            var specializations = _dbContext
              .Specializations
              .ToList();

            var specializationsDto = _mapper.Map<List<Specialization>>(specializations);
            return specializationsDto;
        }

        public int CreateSpecialization(CreateSpecializationDto dto)
        {
            var specialization = _mapper.Map<Specialization>(dto);
            _dbContext.Specializations.Add(specialization);
            _dbContext.SaveChanges();

            return specialization.IdSpecialization;

        }
    }
}
