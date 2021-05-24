using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class RozlczenieEtat
    {
        public RozlczenieEtat()
        {
            RozliczenieSzczegolies = new HashSet<RozliczenieSzczegoly>();
        }

        public int IdRozliczenia { get; set; }
        public int? IdEtat { get; set; }
        public int? IdPracownik { get; set; }
        public DateTime DataWprowadzenia { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int IloscGodzin { get; set; }
        public int? IloscNadgodzin { get; set; }
        public string Uwagi { get; set; }
        public string Opis { get; set; }
        public int? ZabiegiDodatkowoPlatne { get; set; }
        public int? ZabiegiRefundowane { get; set; }
        public int? WizytyOdplatne { get; set; }
        public int? WizytyRefundowane { get; set; }

        public virtual Etat IdEtatNavigation { get; set; }
        public virtual Pracownik IdPracownikNavigation { get; set; }
        public virtual ICollection<RozliczenieSzczegoly> RozliczenieSzczegolies { get; set; }
    }
}
