using AutoMapper;
using iMedical.Models;
using iMedical.Models.TenureTypeModels;
using iMedicalApi.Models;
using iMedicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Services
{
    public interface ITenureTypeService
    {
        int Create(CreateTenureTypeDto dto);
        bool Delete(int id);
        IEnumerable<TenureTypeDto> GetAll();
        TenureTypeDto GetById(int id);
        bool Update(int id, UpdateTenureTypeDto dto);
    }

    public class TenureTypeService : ITenureTypeService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;

        public TenureTypeService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public TenureTypeDto GetById(int id)
        {
            var tenureType = _dbContext
               .TenureTypes
               .FirstOrDefault(r => r.IdTenureType == id);

            if (tenureType is null)
            {
                return null;
            }

            var result = _mapper.Map<TenureTypeDto>(tenureType);
            return result;
        }

        public IEnumerable<TenureTypeDto> GetAll()
        {
            var tenureTypes = _dbContext
                .TenureTypes
                .ToList();

            var tenureTypesDtos = _mapper.Map<List<TenureTypeDto>>(tenureTypes);

            return tenureTypesDtos;
        }


        public int Create(CreateTenureTypeDto dto)
        {
            var tenureType = _mapper.Map<TenureType>(dto);
            _dbContext.TenureTypes.Add(tenureType);
            _dbContext.SaveChanges();

            return tenureType.IdTenureType;
        }

        public bool Delete(int id)
        {
            var tenureType = _dbContext
             .TenureTypes
             .FirstOrDefault(r => r.IdTenureType == id);

            if (tenureType is null) return false;

            _dbContext.TenureTypes.Remove(tenureType);
            _dbContext.SaveChanges();

            return true;


        }

        public bool Update(int id, UpdateTenureTypeDto dto)
        {
            var tenureType = _dbContext
            .TenureTypes
            .FirstOrDefault(r => r.IdTenureType == id);

            if (tenureType is null)
            {
                return false;
            }

            tenureType.Name = dto.Name;

            _dbContext.SaveChanges();

            return true;
        }

    }
}
