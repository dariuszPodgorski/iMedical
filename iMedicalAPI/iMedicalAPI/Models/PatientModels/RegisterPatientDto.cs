using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Models.RegisterUserModels
{
    public class RegisterPatientDto
    {
        public int? IdRole { get; set; } = 1;
       
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        
        [MaxLength(32)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }


        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }


        [Required]
        [MaxLength(16)]
        public string Pesel { get; set; }


        [Required]
        [MaxLength(32)]
        public string CountryRegistration { get; set; }


        [Required]
        [MaxLength(6)]
        public string PostalCodeRegistration { get; set; }


        [Required]
        [MaxLength(64)]
        public string CityRegistration { get; set; }

        [Required]
        [MaxLength(64)]
        public string StreetRegistration { get; set; }

        [Required]
        [MaxLength(11)]
        public string BuildingNumberRegistration { get; set; }

        [MaxLength(11)]
        public string HousingNumberRegistration { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(16)]
        public string Phone { get; set; }
        
        [MaxLength(32)]
        public string CountryResidence { get; set; }

        [MaxLength(6)]
        public string PostalCodeResidence { get; set; }

        [MaxLength(64)]
        public string CityResidence { get; set; }

        [MaxLength(64)]
        public string StreetResidence { get; set; }

        [MaxLength(11)]
        public string BuildingNumberResidence { get; set; }

        [MaxLength(11)]
        public string HouseNumberResidence { get; set; }

        [MaxLength(15)]
        public string InsuranceNumber { get; set; }

     
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
  
        public string Login { get; set; }

    }
}
