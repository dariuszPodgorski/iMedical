using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class MedicalExamination
    {
        public int IdMedicalExamination { get; set; }
        public int? IdMedicalExaminationType { get; set; }
        public int? IdReferral { get; set; }
        public int? IdPriceList { get; set; }
        public int? IdPatient { get; set; }
        public string NumberReferral { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DateEpiration { get; set; }

        public virtual MedicalExaminationType IdMedicalExaminationTypeNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
        public virtual PriceList IdPriceListNavigation { get; set; }
        public virtual Referral IdReferralNavigation { get; set; }
    }
}
