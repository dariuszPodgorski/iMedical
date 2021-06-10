using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Models.PatientModels
{
    public class UserDto
    {
        public int IdUser { get; set; }
        public int? IdRole { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Pesel { get; set; }
        public string CountryRegistration { get; set; }
        public string PostalCodeRegistration { get; set; }
        public string CityRegistration { get; set; }
        public string StreetRegistration { get; set; }
        public string BuildingNumberRegistration { get; set; }
        public string HousingNumberRegistration { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryResidence { get; set; }
        public string PostalCodeResidence { get; set; }
        public string CityResidence { get; set; }
        public string StreetResidence { get; set; }
        public string BuildingNumberResidence { get; set; }
        public string HouseNumberResidence { get; set; }
        public string InsuranceNumber { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
    }
}
