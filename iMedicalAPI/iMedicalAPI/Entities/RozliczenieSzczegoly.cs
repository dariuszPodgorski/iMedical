using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class RozliczenieSzczegoly
    {
        public int IdRozliczenieSzczegoly { get; set; }
        public int? IdPracownik { get; set; }
        public int? IdRozliczenia { get; set; }
        public int? IdKontrakt { get; set; }
        public int? IdEtat { get; set; }
        public DateTime DataPlatnosci { get; set; }
        public DateTime? DataRealizacjiPlatnosci { get; set; }
        public int KwotaSuma { get; set; }
        public string Tytul { get; set; }
        public string Uwagi { get; set; }

        public virtual Etat IdEtatNavigation { get; set; }
        public virtual Kontrakt IdKontraktNavigation { get; set; }
        public virtual Pracownik IdPracownikNavigation { get; set; }
        public virtual RozlczenieEtat IdRozliczeniaNavigation { get; set; }
    }
}
