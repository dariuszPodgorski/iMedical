using AutoMapper;
using iMedical.Models;
using iMedicalApi.Models;
using iMedicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Services
{
    public interface IVisitTypeService
    {
        int Create(CreateVisitTypeDto dto);
        bool Delete(int id);
        IEnumerable<VisitTypeDto> GetAll();
        VisitTypeDto GetById(int id);
    }

    public class VisitTypeService : IVisitTypeService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;

        public VisitTypeService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public VisitTypeDto GetById(int id)
        {
            var visitType = _dbContext
               .VisitTypes
               .FirstOrDefault(r => r.IdVisitType == id);

            if (visitType is null)
            {
                return null;
            }

            var result = _mapper.Map<VisitTypeDto>(visitType);
            return result;
        }

        public IEnumerable<VisitTypeDto> GetAll()
        {
            var visitType = _dbContext
                .VisitTypes
                .ToList();

            var visitTypesDtos = _mapper.Map<List<VisitTypeDto>>(visitType);

            return visitTypesDtos;
        }

        public int Create(CreateVisitTypeDto dto)
        {
            var visitType = _mapper.Map<VisitType>(dto);
            _dbContext.VisitTypes.Add(visitType);
            _dbContext.SaveChanges();

            return visitType.IdVisitType;
        }

        public bool Delete(int id)
        {
            var visitType = _dbContext
             .VisitTypes
             .FirstOrDefault(r => r.IdVisitType == id);

            if (visitType is null) return false;

            _dbContext.VisitTypes.Remove(visitType);
            _dbContext.SaveChanges();

            return true;


        }


    }
}
