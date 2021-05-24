using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class BadanieRodzaj
    {
        public BadanieRodzaj()
        {
            Badanies = new HashSet<Badanie>();
        }

        public int IdBadanieRodzaj { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Badanie> Badanies { get; set; }
    }
}
