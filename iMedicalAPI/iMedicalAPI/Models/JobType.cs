using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class JobType
    {
        public JobType()
        {
            Tenures = new HashSet<Tenure>();
        }

        public int IdJobType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tenure> Tenures { get; set; }
    }
}
