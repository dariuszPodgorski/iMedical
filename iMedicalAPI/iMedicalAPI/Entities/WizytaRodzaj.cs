using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class WizytaRodzaj
    {
        public WizytaRodzaj()
        {
            Wizyta = new HashSet<Wizytum>();
        }

        public int IdWizytaRodzaj { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Wizytum> Wizyta { get; set; }
    }
}
