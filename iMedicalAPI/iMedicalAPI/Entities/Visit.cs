using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Visit
    {
        public int IdVisit { get; set; }
        public int? IdMedicalFacility { get; set; }
        public int? IdPatient { get; set; }
        public int? IdVisitType { get; set; }
        public int? IdPriceList { get; set; }
        public int? IdPrescription { get; set; }
        public int? IdDoctor { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ActivitiesPerformed { get; set; }
        public string Recomendations { get; set; }
        public string GeneralInformation { get; set; }
        public string DosageOfMedication { get; set; }
        public string Comments { get; set; }
        public DateTime DateVisit { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual MedicalFacility IdMedicalFacilityNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
        public virtual Prescription IdPrescriptionNavigation { get; set; }
        public virtual PriceList IdPriceListNavigation { get; set; }
        public virtual VisitType IdVisitTypeNavigation { get; set; }
    }
}
