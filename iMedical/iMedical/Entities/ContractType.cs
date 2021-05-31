using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class ContractType
    {
        public ContractType()
        {
            Contracts = new HashSet<Contract>();
        }

        public int IdContractType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
