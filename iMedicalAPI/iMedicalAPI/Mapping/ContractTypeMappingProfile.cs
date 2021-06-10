using AutoMapper;
using iMedicalApi.Models;
using iMedicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Mapping
{
    public class ContractTypeMappingProfile : Profile
    {
        public ContractTypeMappingProfile()
        {
            CreateMap<ContractType, ContractTypeDto>();
        
            CreateMap<CreateContractTypeDto, ContractType>();
            
        }
    }
}
