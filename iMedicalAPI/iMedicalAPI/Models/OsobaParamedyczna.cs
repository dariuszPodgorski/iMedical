using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class OsobaParamedyczna
    {
        public OsobaParamedyczna()
        {
            Badanies = new HashSet<Badanie>();
            Etats = new HashSet<Etat>();
        }

        public int IdOsobaParamedyczna { get; set; }
        public int? IdTytulRodzaj { get; set; }
        public int? IdSpecjalizacja { get; set; }
        public string Pwz { get; set; }
        public string NrDyplomu { get; set; }
        public string Status { get; set; }

        public virtual Specjalizacja IdSpecjalizacjaNavigation { get; set; }
        public virtual TytulRodzaj IdTytulRodzajNavigation { get; set; }
        public virtual ICollection<Badanie> Badanies { get; set; }
        public virtual ICollection<Etat> Etats { get; set; }
    }
}
