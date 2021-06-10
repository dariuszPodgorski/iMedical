using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class MedicalExaminationType
    {
        public MedicalExaminationType()
        {
            MedicalExaminations = new HashSet<MedicalExamination>();
            Referrals = new HashSet<Referral>();
        }

        public int IdMedicalExaminationType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }
        public virtual ICollection<Referral> Referrals { get; set; }
    }
}
