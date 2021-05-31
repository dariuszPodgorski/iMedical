using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Administration
    {
        public Administration()
        {
            Tenures = new HashSet<Tenure>();
        }

        public int IdAdministration { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Tenure> Tenures { get; set; }
    }
}
