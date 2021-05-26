using AutoMapper;
using iMedicalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Mapping
{
    public class SpecializationMappingProfile : Profile
    {

        public SpecializationMappingProfile()
        {
            CreateMap<CreateSpecializationDto, Specialization>();
        }
    }
}
