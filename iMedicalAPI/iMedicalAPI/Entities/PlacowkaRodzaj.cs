using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class PlacowkaRodzaj
    {
        public PlacowkaRodzaj()
        {
            Placowkas = new HashSet<Placowka>();
        }

        public int IdPlacowkaRodzaj { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Placowka> Placowkas { get; set; }
    }
}
