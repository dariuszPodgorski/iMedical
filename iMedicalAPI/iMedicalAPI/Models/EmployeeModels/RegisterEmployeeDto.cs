using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Models.RegisterUserModels
{
    public class RegisterEmployeeDto
    {
  
        public int IdRole { get; set; }

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
        public string CountryResidence { get; set; }

        [Required]
        [MaxLength(32)]
        public string PostalCodeResidence { get; set; }

        [Required]
        [MaxLength(64)]
        public string CityResidence { get; set; }

        [Required]
        [MaxLength(256)]
        public string StreetResidence { get; set; }

        [Required]
        [MaxLength(11)]
        public string BuildingNumberResidence { get; set; }

        [MaxLength(11)]
        public string HousingNumberResidence { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(16)]
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
