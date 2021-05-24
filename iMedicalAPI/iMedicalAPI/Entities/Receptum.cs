using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Receptum
    {
        public Receptum()
        {
            Wizyta = new HashSet<Wizytum>();
        }

        public int IdRecepta { get; set; }
        public string NrRecepta { get; set; }
        public int Lek1 { get; set; }
        public int? Lek2 { get; set; }
        public int? Lek3 { get; set; }
        public int? Lek4 { get; set; }
        public int? Lek5 { get; set; }
        public int? Lek6 { get; set; }
        public int? Lek7 { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataWaznosci { get; set; }

        public virtual ICollection<Wizytum> Wizyta { get; set; }
    }
}
