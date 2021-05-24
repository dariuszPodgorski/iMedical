using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Skierowanie
    {
        public Skierowanie()
        {
            Badanies = new HashSet<Badanie>();
        }

        public int IdSkierowanie { get; set; }
        public int IdPacjent { get; set; }
        public int IdLekarz { get; set; }
        public int IdBadanieRodzaj { get; set; }
        public string NrSkierowania { get; set; }
        public DateTime DataWystawienia { get; set; }
        public int DataWaznosci { get; set; }

        public virtual Lekarz IdLekarzNavigation { get; set; }
        public virtual Pacjent IdPacjentNavigation { get; set; }
        public virtual ICollection<Badanie> Badanies { get; set; }
    }
}
