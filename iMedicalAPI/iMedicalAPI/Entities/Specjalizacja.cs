using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Specjalizacja
    {
        public Specjalizacja()
        {
            LekarzSpecjalizacjas = new HashSet<LekarzSpecjalizacja>();
            OsobaParamedycznas = new HashSet<OsobaParamedyczna>();
        }

        public int IdSpecjalizacja { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<LekarzSpecjalizacja> LekarzSpecjalizacjas { get; set; }
        public virtual ICollection<OsobaParamedyczna> OsobaParamedycznas { get; set; }
    }
}
