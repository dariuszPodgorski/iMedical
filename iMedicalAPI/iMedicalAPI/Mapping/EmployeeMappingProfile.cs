using AutoMapper;
using iMedicalAPI.Models;
using iMedicalAPI.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeDto, Employee>();
        }
    }
}
