using iMedicalAPI.Models.RegisterUserModels;
using System.Collections.Generic;
using System.Linq;
using iMedicalAPI.Models;
using iMedical.Models;
using Microsoft.AspNetCore.Identity;
using iMedicalAPI.Exceptions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace iMedicalAPI.Services
{
    public interface IAccountService
    {
        void RegisterPatient(RegisterPatientDto dto);
        string GenerateJwt(LoginDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly iMedical_angContext _context;
        private readonly IPasswordHasher<UserAccount> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(iMedical_angContext context, IPasswordHasher<UserAccount> passwordHasher, AuthenticationSettings authenticationSettings )
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;

        }
        public void RegisterPatient(RegisterPatientDto dto)
        {
           
            var newPatient = new UserAccount()
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
                Login = dto.Login,
                IdRole = dto.IdRole
            };

            var hashedPassword = _passwordHasher.HashPassword(newPatient, dto.Password);
            
            newPatient.Password = hashedPassword;
            _context.UserAccounts.Add(newPatient);
            _context.SaveChanges();
        }

        


        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.UserAccounts
                .Include(u => u.IdRoleNavigation)
                .FirstOrDefault(u => u.Login == dto.Login);
                
            if (user is null)
            {
                throw new BadRequestException("Nieporpawny login lub hasło");
            }

            var result =  _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Nieporpawny hasło");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.IdRoleNavigation.Name}"),
             

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtEpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
        
    }
}
