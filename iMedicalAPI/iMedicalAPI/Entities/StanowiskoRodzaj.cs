using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class StanowiskoRodzaj
    {
        public StanowiskoRodzaj()
        {
            Etats = new HashSet<Etat>();
        }

        public int IdStanowiskoRodzaj { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Etat> Etats { get; set; }
    }
}
