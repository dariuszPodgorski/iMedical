using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class TytulRodzaj
    {
        public TytulRodzaj()
        {
            Lekarzs = new HashSet<Lekarz>();
            OsobaParamedycznas = new HashSet<OsobaParamedyczna>();
        }

        public int IdTytulRodzaj { get; set; }
        public string Nazwa { get; set; }
        public string Kod { get; set; }

        public virtual ICollection<Lekarz> Lekarzs { get; set; }
        public virtual ICollection<OsobaParamedyczna> OsobaParamedycznas { get; set; }
    }
}
