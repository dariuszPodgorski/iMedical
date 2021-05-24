using AutoMapper;
using iMedicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Mapping
{
    public class SpecializationMappingProfile : Profile
    {

        public SpecializationMappingProfile()
        {
            CreateMap<Specjalizacja, SpecializationDto>()
                .ForMember(a => a.Name, c => c.MapFrom(s => s.Nazwa));
        }
    }
}
