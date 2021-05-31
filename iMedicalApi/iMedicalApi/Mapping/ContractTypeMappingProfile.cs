﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedicalApi.Models;

namespace iMedicalApi.Mapping
{
    public class ContractTypeMappingProfile : Profile
    {
        public ContractTypeMappingProfile()
        {
            CreateMap<ContractType, ContractTypeDto>();

            CreateMap<ContractTypeDto, ContractType>();
        }
    }
}