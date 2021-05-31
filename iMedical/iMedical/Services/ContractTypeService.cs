using AutoMapper;
using iMedical.Models;
using iMedicalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Services
{
    public interface IContractTypeService
    {
        int Create(CreateContractTypeDto dto);
        bool Delete(int id);
        IEnumerable<ContractTypeDto> GetAll();
        ContractTypeDto GetById(int id);
    }

    public class ContractTypeService : IContractTypeService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;

        public ContractTypeService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ContractTypeDto GetById(int id)
        {
            var contractType = _dbContext
               .ContractTypes
               .FirstOrDefault(r => r.IdContractType == id);

            if (contractType is null)
            {
                return null;
            }

            var result = _mapper.Map<ContractTypeDto>(contractType);
            return result;
        }

        public IEnumerable<ContractTypeDto> GetAll()
        {
            var contractTypes = _dbContext
                .ContractTypes
                .ToList();

            var contractTypesDtos = _mapper.Map<List<ContractTypeDto>>(contractTypes);

            return contractTypesDtos;
        }

        public int Create(CreateContractTypeDto dto)
        {
            var contractType = _mapper.Map<ContractType>(dto);
            _dbContext.ContractTypes.Add(contractType);
            _dbContext.SaveChanges();

            return contractType.IdContractType;
        }

        public bool Delete(int id)
        {
            var contractType = _dbContext
             .ContractTypes
             .FirstOrDefault(r => r.IdContractType == id);

            if (contractType is null) return false;

            _dbContext.ContractTypes.Remove(contractType);
            _dbContext.SaveChanges();

            return true;


        }

    }
}
