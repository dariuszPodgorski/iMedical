using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Models
{
    public class PatientDto
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }  
        public DateTime DateOfBirth { get; set; }
        public string Pesel { get; set; }
        public string InsuranceNumber { get; set; }


    }
}
