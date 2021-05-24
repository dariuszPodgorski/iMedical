using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Badanie
    {
        public int IdBadanie { get; set; }
        public int IdOsobaParamedyczna { get; set; }
        public int IdCena { get; set; }
        public int? IdSkierowanie { get; set; }
        public int IdBadanieRodzaj { get; set; }
        public int IdPacjent { get; set; }
        public DateTime DataBadania { get; set; }
        public DateTime DataRejestracji { get; set; }

        public virtual BadanieRodzaj IdBadanieRodzajNavigation { get; set; }
        public virtual Cennik IdCenaNavigation { get; set; }
        public virtual OsobaParamedyczna IdOsobaParamedycznaNavigation { get; set; }
        public virtual Pacjent IdPacjentNavigation { get; set; }
        public virtual Skierowanie IdSkierowanieNavigation { get; set; }
    }
}
