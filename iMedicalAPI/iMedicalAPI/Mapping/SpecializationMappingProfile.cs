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
    public class SpecializationMappingProfile : Profile
    {
        public SpecializationMappingProfile()
        {
            CreateMap<Specialization, SpecializationDto>();
                /*.ForMember(m => m.Name, c => c.MapFrom(s => s.Name)); */


            CreateMap<CreateContracTypeDto, Specialization>();
               /* .ForMember(r => r.Name, c => c.MapFrom(dto => new Specialization() 
                { Name = dto.Name })); */
        }

    }
}
