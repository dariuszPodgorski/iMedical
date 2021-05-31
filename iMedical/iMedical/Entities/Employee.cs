using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Employee
    {
        public Employee()
        {
            BillingTenures = new HashSet<BillingTenure>();
            Logins = new HashSet<Login>();
            PaymentDetails = new HashSet<PaymentDetail>();
            Tenures = new HashSet<Tenure>();
        }

        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Pesel { get; set; }
        public string CountryResidence { get; set; }
        public string PostalCodeResidence { get; set; }
        public string CityResidence { get; set; }
        public string StreetResidence { get; set; }
        public string BuildingNumberResidence { get; set; }
        public string HousingNumberResidence { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<BillingTenure> BillingTenures { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Tenure> Tenures { get; set; }
    }
}
