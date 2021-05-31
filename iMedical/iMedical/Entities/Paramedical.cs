using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class Paramedical
    {
        public Paramedical()
        {
            Tenures = new HashSet<Tenure>();
        }

        public int IdParamedical { get; set; }
        public int? IdTytleType { get; set; }
        public string Pwz { get; set; }
        public string CerificateNumber { get; set; }
        public string Status { get; set; }

        public virtual TitleType IdTytleTypeNavigation { get; set; }
        public virtual ICollection<Tenure> Tenures { get; set; }
    }
}
