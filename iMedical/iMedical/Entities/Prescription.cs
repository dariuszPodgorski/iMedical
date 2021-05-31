using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            Visits = new HashSet<Visit>();
        }

        public int IdPrescription { get; set; }
        public string NumberPrescription { get; set; }
        public string Medication1 { get; set; }
        public string Medication2 { get; set; }
        public string Medication3 { get; set; }
        public string Medication4 { get; set; }
        public string Medication5 { get; set; }
        public string Medication6 { get; set; }
        public string Medication7 { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DateExpiration { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
