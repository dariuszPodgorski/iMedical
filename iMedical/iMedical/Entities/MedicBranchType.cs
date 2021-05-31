using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
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
