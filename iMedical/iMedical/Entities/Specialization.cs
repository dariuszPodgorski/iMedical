using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            DoctorSpecializations = new HashSet<DoctorSpecialization>();
        }

        public int IdSpecialization { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
    }
}
