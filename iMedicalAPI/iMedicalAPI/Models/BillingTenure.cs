using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class BillingTenure
    {
        public BillingTenure()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int IdBillingTenure { get; set; }
        public int? IdTenure { get; set; }
        public int? IdUser { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? HoursNumber { get; set; }
        public int? HoursExtraNumber { get; set; }
        public string Comments { get; set; }
        public string Description { get; set; }
        public int? TreatmentsPaid { get; set; }
        public int? TreatmentsReimbursed { get; set; }
        public int? VisitsPaid { get; set; }
        public int? VisitsReimbursed { get; set; }

        public virtual Tenure IdTenureNavigation { get; set; }
        public virtual UserAccount IdUserNavigation { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
