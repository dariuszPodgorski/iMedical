using iMedicalAPI.Models.RegisterUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedicalAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace iMedicalAPI.Services
{
    public interface IAccountService
    {
        void RegisterPatient(RegisterPatientDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly iMedical_angContext _context;
        private readonly IPasswordHasher<Patient> _passwordHasher;

        public AccountService(iMedical_angContext context, IPasswordHasher<Patient> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;

        }
        public void RegisterPatient(RegisterPatientDto dto )
        {
           
            var newPatient = new Patient()
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                Pesel = dto.Pesel,
                CountryRegistration = dto.CountryRegistration,
                PostalCodeRegistration = dto.PostalCodeRegistration,
                CityRegistration = dto.CityRegistration,
                StreetRegistration = dto.StreetRegistration,
                BuildingNumberRegistration = dto.BuildingNumberRegistration,
                HousingNumberRegistration = dto.HousingNumberRegistration,
                Email = dto.Email,
                Phone = dto.Phone,
                CountryResidence = dto.CountryResidence,
                CityResidence = dto.CityResidence,
                StreetResidence = dto.StreetResidence,
                BuildingNumberResidence = dto.BuildingNumberResidence,
                HouseNumberResidence = dto.HouseNumberResidence,
                InsuranceNumber = dto.InsuranceNumber,
                Login = dto.Login,
                IdRole = dto.IdRole
            };

            var hashedPassword = _passwordHasher.HashPassword(newPatient, dto.Password);
            
            newPatient.Password = hashedPassword;
            _context.Patients.Add(newPatient);
            _context.SaveChanges();
        }

        

    }
}
