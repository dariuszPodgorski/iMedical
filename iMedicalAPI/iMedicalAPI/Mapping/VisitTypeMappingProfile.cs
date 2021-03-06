using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedicalApi.Models;
using iMedical.Models;
using iMedicalAPI.Models;

namespace iMedicalApi.Mapping
{
    public class VisitTypeMappingProfile : Profile
    {
        public VisitTypeMappingProfile()
        {
            CreateMap<VisitType, VisitTypeDto>();
            CreateMap<CreateVisitTypeDto, VisitType>();
            
        }

    }
}
