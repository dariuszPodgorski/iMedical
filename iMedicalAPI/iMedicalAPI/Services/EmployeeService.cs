using AutoMapper;
using iMedicalAPI.Models;
using iMedicalAPI.Models.EmployeeModels;
using iMedicalAPI.Models.RegisterUserModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Services
{
    public interface IEmployeeService
    {
        void RegisterEmployee(RegisterEmployeeDto dto);
        IEnumerable<EmployeeDto> GetAll();
        EmployeeDto GetById(int id);

    }

    public class EmployeeService : IEmployeeService
    {
        private readonly iMedical_angContext _context;
        private readonly IPasswordHasher<Employee> _passwordHasher;
        private readonly IMapper _mapper;

        public EmployeeService(iMedical_angContext context, IPasswordHasher<Employee> passwordHasher, IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;

        }
        public void RegisterEmployee(RegisterEmployeeDto dto)
        {

            var newEmployee = new Employee()
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                Pesel = dto.Pesel,
                Email = dto.Email,
                Phone = dto.Phone,
                CountryResidence = dto.CountryResidence,
                CityResidence = dto.CityResidence,
                StreetResidence = dto.StreetResidence,
                BuildingNumberResidence = dto.BuildingNumberResidence,
                Login = dto.Login,
                IdRole = dto.IdRole
            };

            var hashedPassword = _passwordHasher.HashPassword(newEmployee, dto.Password);

            newEmployee.Password = hashedPassword;
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
        }


        public EmployeeDto GetById(int id)
        {
            var employee = _context
               .Employees
               .FirstOrDefault(r => r.IdEmployee == id);

            if (employee is null)
            {
                return null;
            }

            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _context
                .Employees
                .ToList();

            var employeesDtos = _mapper.Map<List<EmployeeDto>>(employees);

            return employeesDtos;
        }
    }
}
