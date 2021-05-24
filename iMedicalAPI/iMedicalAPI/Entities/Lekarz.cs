using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Lekarz
    {
        public Lekarz()
        {
            Etats = new HashSet<Etat>();
            LekarzSpecjalizacjas = new HashSet<LekarzSpecjalizacja>();
            Skierowanies = new HashSet<Skierowanie>();
            Wizyta = new HashSet<Wizytum>();
        }

        public int IdLekarz { get; set; }
        public int? IdTytulRodzaj { get; set; }
        public string Pwz { get; set; }
        public string NrDyplomu { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string NrTelefonu { get; set; }

        public virtual TytulRodzaj IdTytulRodzajNavigation { get; set; }
        public virtual ICollection<Etat> Etats { get; set; }
        public virtual ICollection<LekarzSpecjalizacja> LekarzSpecjalizacjas { get; set; }
        public virtual ICollection<Skierowanie> Skierowanies { get; set; }
        public virtual ICollection<Wizytum> Wizyta { get; set; }
    }
}
