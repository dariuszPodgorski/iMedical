using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class VisitType
    {
        public VisitType()
        {
            Visits = new HashSet<Visit>();
        }

        public int IdVisitType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
