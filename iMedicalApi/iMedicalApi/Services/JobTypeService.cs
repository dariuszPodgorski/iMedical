using AutoMapper;
using iMedicalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Services
{
    public interface IJobTypeService
    {
        int Create(CreateJobTypeDto dto);
        bool Delete(int id);
        IEnumerable<JobTypeDto> GetAll();
        JobTypeDto GetById(int id);
    }

    public class JobTypeService : IJobTypeService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;

        public JobTypeService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public JobTypeDto GetById(int id)
        {
            var jobType = _dbContext
               .JobTypes
               .FirstOrDefault(r => r.IdJobType == id);

            if (jobType is null)
            {
                return null;
            }

            var result = _mapper.Map<JobTypeDto>(jobType);
            return result;
        }

        public IEnumerable<JobTypeDto> GetAll()
        {
            var jobTypes = _dbContext
                .JobTypes
                .ToList();

            var jobTypesDtos = _mapper.Map<List<JobTypeDto>>(jobTypes);

            return jobTypesDtos;
        }

        public int Create(CreateJobTypeDto dto)
        {
            var jobType = _mapper.Map<JobType>(dto);
            _dbContext.JobTypes.Add(jobType);
            _dbContext.SaveChanges();

            return jobType.IdJobType;
        }

        public bool Delete(int id)
        {
            var jobType = _dbContext
             .JobTypes
             .FirstOrDefault(r => r.IdJobType == id);

            if (jobType is null) return false;

            _dbContext.JobTypes.Remove(jobType);
            _dbContext.SaveChanges();

            return true;


        }


    }
}
