using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            DoctorSpecializations = new HashSet<DoctorSpecialization>();
            Referrals = new HashSet<Referral>();
            Tenures = new HashSet<Tenure>();
            Visits = new HashSet<Visit>();
        }

        public int IdDoctor { get; set; }
        public int? IdTytleType { get; set; }
        public string Pwz { get; set; }
        public string CertificateNumber { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual TitleType IdTytleTypeNavigation { get; set; }
        public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
        public virtual ICollection<Referral> Referrals { get; set; }
        public virtual ICollection<Tenure> Tenures { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
