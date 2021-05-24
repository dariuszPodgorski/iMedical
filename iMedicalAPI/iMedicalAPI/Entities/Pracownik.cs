using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            Etats = new HashSet<Etat>();
            Logins = new HashSet<Login>();
            RozlczenieEtats = new HashSet<RozlczenieEtat>();
            RozliczenieSzczegolies = new HashSet<RozliczenieSzczegoly>();
        }

        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string DrugieImie { get; set; }
        public string Nazwisko { get; set; }
        public string Plec { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public string KrajZameldowania { get; set; }
        public string KodPocztowyZameldowania { get; set; }
        public string MiejscowoscZameldowania { get; set; }
        public string UlicaZameldowania { get; set; }
        public string NrBudynkuZameldowania { get; set; }
        public string NrLokaluZameldowania { get; set; }
        public string Email { get; set; }
        public string NrKontaktowy { get; set; }

        public virtual ICollection<Etat> Etats { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<RozlczenieEtat> RozlczenieEtats { get; set; }
        public virtual ICollection<RozliczenieSzczegoly> RozliczenieSzczegolies { get; set; }
    }
}
