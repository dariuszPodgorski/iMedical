using AutoMapper;
using iMedicalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(m => m.FirstName, c => c.MapFrom(s => s.FirstName))
                .ForMember(m => m.MiddleName, c => c.MapFrom(s => s.MiddleName))
                .ForMember(m => m.LastName, c => c.MapFrom(s => s.LastName))
                .ForMember(m => m.DateOfBirth, c => c.MapFrom(s => s.DateOfBirth))
                .ForMember(m => m.Pesel, c => c.MapFrom(s => s.Pesel))
                .ForMember(m => m.InsuranceNumber, c => c.MapFrom(s => s.InsuranceNumber));

            CreateMap<CreatePatientDto, Patient>()
                .ForMember(l => l.Logins, d => d.MapFrom(dto => new Login() 
                    { Login1 = dto.Login1, Password = dto.Password }));
        }
    }
}
