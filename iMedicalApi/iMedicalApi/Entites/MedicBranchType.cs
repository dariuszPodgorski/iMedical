using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalApi.Models
{
    public partial class MedicBranchType
    {
        public MedicBranchType()
        {
            Contracts = new HashSet<Contract>();
            MedicalFacilities = new HashSet<MedicalFacility>();
        }

        public int IdMedicalBranchType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<MedicalFacility> MedicalFacilities { get; set; }
    }
}
