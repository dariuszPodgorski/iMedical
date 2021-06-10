using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class DoctorSpecialization
    {
        public int IdDoctor { get; set; }
        public int IdSpecialization { get; set; }
        public int IdDoctorSpecialization { get; set; }
        public DateTime Date { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Specialization IdSpecializationNavigation { get; set; }
    }
}
