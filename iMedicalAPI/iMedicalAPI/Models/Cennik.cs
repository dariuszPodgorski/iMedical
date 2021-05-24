using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Cennik
    {
        public Cennik()
        {
            Badanies = new HashSet<Badanie>();
            Wizyta = new HashSet<Wizytum>();
        }

        public int IdCena { get; set; }
        public string Nazwa { get; set; }
        public int Stawka { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Badanie> Badanies { get; set; }
        public virtual ICollection<Wizytum> Wizyta { get; set; }
    }
}
