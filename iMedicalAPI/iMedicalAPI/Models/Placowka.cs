using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Placowka
    {
        public Placowka()
        {
            Kontrakts = new HashSet<Kontrakt>();
            Wizyta = new HashSet<Wizytum>();
        }

        public int IdPlacowka { get; set; }
        public int? IdPlacowkaRodzaj { get; set; }
        public string NazwaDluga { get; set; }
        public string NazwaKrotka { get; set; }
        public string Miejscowosc { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public string NrBudynku { get; set; }
        public string NrLokalu { get; set; }
        public string Nip { get; set; }
        public int? PlacowkaGlownaId { get; set; }
        public string Aktywnosc { get; set; }

        public virtual PlacowkaRodzaj IdPlacowkaRodzajNavigation { get; set; }
        public virtual ICollection<Kontrakt> Kontrakts { get; set; }
        public virtual ICollection<Wizytum> Wizyta { get; set; }
    }
}
