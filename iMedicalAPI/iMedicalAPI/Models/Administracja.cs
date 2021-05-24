using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Administracja
    {
        public Administracja()
        {
            Etats = new HashSet<Etat>();
        }

        public int IdAdministracja { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Etat> Etats { get; set; }
    }
}
