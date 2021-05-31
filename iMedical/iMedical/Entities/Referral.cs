﻿using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Referral
    {
        public Referral()
        {
            MedicalExaminations = new HashSet<MedicalExamination>();
        }

        public int IdReferral { get; set; }
        public int? IdPatient { get; set; }
        public int? IdMedicalExaminationType { get; set; }
        public int? IdDoctor { get; set; }
        public string ReferralNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual MedicalExaminationType IdMedicalExaminationTypeNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }
    }
}