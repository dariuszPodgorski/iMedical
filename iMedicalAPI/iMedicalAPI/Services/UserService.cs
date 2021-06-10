using AutoMapper;
using iMedicalAPI.Models;
using iMedicalAPI.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly iMedical_angContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(iMedical_angContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDto GetById(int id)
        {
            var user = _dbContext
               .UserAccounts
               .FirstOrDefault(r => r.IdUser == id);

            if (user is null)
            {
                return null;
            }

            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var user = _dbContext
                .UserAccounts
                .ToList();

            var usersDtos = _mapper.Map<List<UserDto>>(user);

            return usersDtos;
        }

    }
}
