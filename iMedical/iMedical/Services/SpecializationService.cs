using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iMedical.Models;
using iMedicalApi.Models;

namespace iMedicalApi.Services
{
    public interface ISpecializationService
    {
        int Create(CreateSpecializationDto dto);
        IEnumerable<SpecializationDto> GetAll();
        SpecializationDto GetById(int id);
        bool Delete(int id);
        bool Update(int id, UpdateSpecializationDto dto);
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
               .FirstOrDefault(r => r.IdSpecialization == id);

            if (specialization is null)
            {
                return null;
            }

            var result = _mapper.Map<SpecializationDto>(specialization);
            return result;
        }
        public IEnumerable<SpecializationDto> GetAll()
        {
            var specializations = _dbContext
                .Specializations
                .ToList();

            var specializationsDtos = _mapper.Map<List<SpecializationDto>>(specializations);

            return specializationsDtos;
        }

        public int Create(CreateSpecializationDto dto)
        {
            var specialization = _mapper.Map<Specialization>(dto);
            _dbContext.Specializations.Add(specialization);
            _dbContext.SaveChanges();

            return specialization.IdSpecialization;
        }

        public bool Delete(int id)
        {
            var specialization = _dbContext
             .Specializations
             .FirstOrDefault(r => r.IdSpecialization == id);
            
            if (specialization is null) return false;

            _dbContext.Specializations.Remove(specialization);
            _dbContext.SaveChanges();
            
            return true;


        }

        public bool Update(int id, UpdateSpecializationDto dto)
        {
            var specialization = _dbContext
            .Specializations
            .FirstOrDefault(r => r.IdSpecialization == id);

            if(specialization is null)
            {
                return false;
            }

            specialization.Name = dto.Name;

            _dbContext.SaveChanges();

            return true;
        }

    }

}
