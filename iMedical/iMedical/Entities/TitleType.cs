using System;
using System.Collections.Generic;

#nullable disable

namespace iMedical.Models
{
    public partial class TitleType
    {
        public TitleType()
        {
            Doctors = new HashSet<Doctor>();
            Paramedicals = new HashSet<Paramedical>();
        }

        public int IdTytleType { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Paramedical> Paramedicals { get; set; }
    }
}
