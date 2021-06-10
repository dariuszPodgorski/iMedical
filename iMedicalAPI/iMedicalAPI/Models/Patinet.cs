using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Patinet
    {
        public int IdPatient { get; set; }
        public int? IdUser { get; set; }
        public string InsuranceNumber { get; set; }

        public virtual UserAccount IdUserNavigation { get; set; }
    }
}
