using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Wizytum
    {
        public int IdWizyta { get; set; }
        public int? IdPacjent { get; set; }
        public int? IdLekarz { get; set; }
        public int? IdCena { get; set; }
        public int? IdRecepta { get; set; }
        public int? IdWizytaRodzaj { get; set; }
        public int? IdPlacowka { get; set; }
        public DateTime DataRejestracji { get; set; }
        public DateTime DataWizyty { get; set; }
        public string Informacje { get; set; }
        public string PrzeprowadzoneCzynnosci { get; set; }
        public string Zalecenia { get; set; }
        public string InfromacjaOgolna { get; set; }
        public string DawkowanieLekow { get; set; }
        public string Uwagi { get; set; }

        public virtual Cennik IdCenaNavigation { get; set; }
        public virtual Lekarz IdLekarzNavigation { get; set; }
        public virtual Pacjent IdPacjentNavigation { get; set; }
        public virtual Placowka IdPlacowkaNavigation { get; set; }
        public virtual Receptum IdReceptaNavigation { get; set; }
        public virtual WizytaRodzaj IdWizytaRodzajNavigation { get; set; }
    }
}
