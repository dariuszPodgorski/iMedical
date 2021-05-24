using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Etat
    {
        public Etat()
        {
            Kontrakts = new HashSet<Kontrakt>();
            RozlczenieEtats = new HashSet<RozlczenieEtat>();
            RozliczenieSzczegolies = new HashSet<RozliczenieSzczegoly>();
        }

        public int IdEtat { get; set; }
        public int IdStanowiskoRodzaj { get; set; }
        public int IdEtatRodzaj { get; set; }
        public int? IdOsobaParamedyczna { get; set; }
        public int? IdPracownik { get; set; }
        public int? IdAdministracja { get; set; }
        public int? IdLekarz { get; set; }
        public string Email { get; set; }
        public string NrTelefonu { get; set; }

        public virtual Administracja IdAdministracjaNavigation { get; set; }
        public virtual EtatRodzaj IdEtatRodzajNavigation { get; set; }
        public virtual Lekarz IdLekarzNavigation { get; set; }
        public virtual OsobaParamedyczna IdOsobaParamedycznaNavigation { get; set; }
        public virtual Pracownik IdPracownikNavigation { get; set; }
        public virtual StanowiskoRodzaj IdStanowiskoRodzajNavigation { get; set; }
        public virtual ICollection<Kontrakt> Kontrakts { get; set; }
        public virtual ICollection<RozlczenieEtat> RozlczenieEtats { get; set; }
        public virtual ICollection<RozliczenieSzczegoly> RozliczenieSzczegolies { get; set; }
    }
}
