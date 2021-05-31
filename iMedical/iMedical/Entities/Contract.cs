using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Contract
    {
        public Contract()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int IdContract { get; set; }
        public int? IdContractType { get; set; }
        public int? IdTenure { get; set; }
        public int? IdMedicalBranchType { get; set; }
        public int? IdMedicalFacility { get; set; }
        public int? Bonus { get; set; }
        public int? HourlyRate { get; set; }
        public int? MonthlyRate { get; set; }
        public string Comments { get; set; }
        public string NumberAccount { get; set; }
        public DateTime ConclusionDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public virtual ContractType IdContractTypeNavigation { get; set; }
        public virtual MedicBranchType IdMedicalBranchTypeNavigation { get; set; }
        public virtual MedicalFacility IdMedicalFacilityNavigation { get; set; }
        public virtual Tenure IdTenureNavigation { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
