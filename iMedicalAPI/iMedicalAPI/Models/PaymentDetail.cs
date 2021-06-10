using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class PaymentDetail
    {
        public int IdPaymentDetails { get; set; }
        public int? IdContract { get; set; }
        public int? IdUser { get; set; }
        public int? IdBillingTenure { get; set; }
        public int? IdTenure { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public int Total { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }

        public virtual BillingTenure IdBillingTenureNavigation { get; set; }
        public virtual Contract IdContractNavigation { get; set; }
        public virtual Tenure IdTenureNavigation { get; set; }
        public virtual UserAccount IdUserNavigation { get; set; }
    }
}
