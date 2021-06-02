using AutoMapper;
using iMedical.Models;
using iMedicalApi.Models;
using iMedicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Mapping
{
    public class TenureTypeMappingProfile : Profile
    {
        public TenureTypeMappingProfile()
        {
            CreateMap<TenureType, TenureTypeDto>();

            CreateMap<CreateTenureTypeDto, TenureType>();
        }
    }
}
