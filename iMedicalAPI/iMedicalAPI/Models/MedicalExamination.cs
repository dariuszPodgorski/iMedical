using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class MedicalExamination
    {
        public int IdMedicalExamination { get; set; }
        public int? IdMedicalExaminationType { get; set; }
        public int? IdReferral { get; set; }
        public int? IdPriceList { get; set; }
        public int? IdUser { get; set; }
        public string NumberReferral { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DateEpiration { get; set; }

        public virtual MedicalExaminationType IdMedicalExaminationTypeNavigation { get; set; }
        public virtual PriceList IdPriceListNavigation { get; set; }
        public virtual Referral IdReferralNavigation { get; set; }
        public virtual UserAccount IdUserNavigation { get; set; }
    }
}
