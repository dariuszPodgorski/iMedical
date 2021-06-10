using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Referral
    {
        public Referral()
        {
            MedicalExaminations = new HashSet<MedicalExamination>();
        }

        public int IdReferral { get; set; }
        public int? IdUser { get; set; }
        public int? IdMedicalExaminationType { get; set; }
        public int? IdDoctor { get; set; }
        public string ReferralNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual MedicalExaminationType IdMedicalExaminationTypeNavigation { get; set; }
        public virtual UserAccount IdUserNavigation { get; set; }
        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }
    }
}
