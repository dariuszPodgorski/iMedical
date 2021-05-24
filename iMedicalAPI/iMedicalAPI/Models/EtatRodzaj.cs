using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class EtatRodzaj
    {
        public EtatRodzaj()
        {
            Etats = new HashSet<Etat>();
        }

        public int IdEtatRodzaj { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Etat> Etats { get; set; }
    }
}
