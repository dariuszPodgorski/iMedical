using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class MedicBranchType
    {
        public MedicBranchType()
        {
            Contracts = new HashSet<Contract>();
        }

        public int IdMedicalBranchType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
