using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalApi.Models
{
    public partial class MedicalFacility
    {
        public MedicalFacility()
        {
            Contracts = new HashSet<Contract>();
            Visits = new HashSet<Visit>();
        }

        public int IdMedicalFacility { get; set; }
        public int? IdMedicalBranchType { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Nip { get; set; }
        public string Status { get; set; }

        public virtual MedicBranchType IdMedicalBranchTypeNavigation { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
