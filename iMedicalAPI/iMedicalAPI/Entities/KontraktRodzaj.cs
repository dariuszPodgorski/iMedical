using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class KontraktRodzaj
    {
        public KontraktRodzaj()
        {
            Kontrakts = new HashSet<Kontrakt>();
        }

        public int IdKontraktRodzaj { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Kontrakt> Kontrakts { get; set; }
    }
}
