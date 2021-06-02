using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Tenure
    {
        public Tenure()
        {
            BillingTenures = new HashSet<BillingTenure>();
            Contracts = new HashSet<Contract>();
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int IdTenure { get; set; }
        public int? IdParamedical { get; set; }
        public int? IdJobType { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdAdministration { get; set; }
        public int? IdTenureType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual Administration IdAdministrationNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual JobType IdJobTypeNavigation { get; set; }
        public virtual Paramedical IdParamedicalNavigation { get; set; }
        public virtual TenureType IdTenureTypeNavigation { get; set; }
        public virtual ICollection<BillingTenure> BillingTenures { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
