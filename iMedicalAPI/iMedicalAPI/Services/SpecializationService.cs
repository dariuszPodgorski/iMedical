using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iMedical.Models;
using iMedicalApi.Models;
using iMedicalAPI.Models;
using Microsoft.Extensions.Logging;

namespace iMedicalApi.Services
{
    public interface ISpecializationService
    {
        int Create(CreateContracTypeDto dto);
        IEnumerable<SpecializationDto> GetAll();
        SpecializationDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateSpecializationDto dto);
    }

    public class SpecializationService : ISpecializationService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<SpecializationService> _logger;

        public SpecializationService(iMedical_angContext dbContext, IMapper mapper, ILogger<SpecializationService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public SpecializationDto GetById(int id)
        {
            var specialization = _dbContext
               .Specializations
               .FirstOrDefault(r => r.IdSpecialization == id);

            if (specialization is null)

                throw new DllNotFoundException("Not found");

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

        public int Create(CreateContracTypeDto dto)
        {
            var specialization = _mapper.Map<Specialization>(dto);
            _dbContext.Specializations.Add(specialization);
            _dbContext.SaveChanges();

            return specialization.IdSpecialization;
        }

       
        public void Delete(int id)
        {
         
            var specialization = _dbContext
             .Specializations
             .FirstOrDefault(r => r.IdSpecialization == id);
            
            if (specialization is null) 
                throw new DllNotFoundException("Not found");

            _dbContext.Specializations.Remove(specialization);
            _dbContext.SaveChanges();
            
          


        }

        public void Update(int id, UpdateSpecializationDto dto)
        {
            var specialization = _dbContext
            .Specializations
            .FirstOrDefault(r => r.IdSpecialization == id);

            if (specialization is null) 
                throw new DllNotFoundException("Not found");

            specialization.Name = dto.Name;

            _dbContext.SaveChanges();

    
        }

    }

}
