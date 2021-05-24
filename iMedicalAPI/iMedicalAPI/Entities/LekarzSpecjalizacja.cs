using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class LekarzSpecjalizacja
    {
        public int IdLekarzSpecjalizacja { get; set; }
        public int? IdSpecjalizacja { get; set; }
        public int? IdLekarz { get; set; }
        public DateTime DataOtrzymania { get; set; }

        public virtual Lekarz IdLekarzNavigation { get; set; }
        public virtual Specjalizacja IdSpecjalizacjaNavigation { get; set; }
    }
}
