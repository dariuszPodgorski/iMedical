using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Kontrakt
    {
        public Kontrakt()
        {
            RozliczenieSzczegolies = new HashSet<RozliczenieSzczegoly>();
        }

        public int IdKontrakt { get; set; }
        public int? IdKontraktRodzaj { get; set; }
        public int? IdEtat { get; set; }
        public int? IdPlacowka { get; set; }
        public int? PlacaPodstawowa { get; set; }
        public int? Premia { get; set; }
        public int? StawkaGodzinowa { get; set; }
        public int? StawkaRyczaltowa { get; set; }
        public string Uwagi { get; set; }
        public string NrKonta { get; set; }
        public DateTime DataZawarcia { get; set; }
        public DateTime? DataZakonczenia { get; set; }

        public virtual Etat IdEtatNavigation { get; set; }
        public virtual KontraktRodzaj IdKontraktRodzajNavigation { get; set; }
        public virtual Placowka IdPlacowkaNavigation { get; set; }
        public virtual ICollection<RozliczenieSzczegoly> RozliczenieSzczegolies { get; set; }
    }
}
