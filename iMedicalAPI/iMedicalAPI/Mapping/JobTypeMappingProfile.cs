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
    public class JobTypeMappingProfile : Profile
    {
        public JobTypeMappingProfile()
        {
            CreateMap<JobType, JobTypeDto>();

            CreateMap<CreateJobTypeDto, JobType>();
        }
    }
}
