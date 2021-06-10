using AutoMapper;
using iMedicalAPI.Models;
using iMedicalAPI.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserAccount, UserDto>();

            CreateMap<UserDto, UserAccount>();
        }
    }
}
