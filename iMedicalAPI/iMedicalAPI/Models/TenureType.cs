using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class TenureType
    {
        public TenureType()
        {
            Tenures = new HashSet<Tenure>();
        }

        public int IdTenureType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tenure> Tenures { get; set; }
    }
}
