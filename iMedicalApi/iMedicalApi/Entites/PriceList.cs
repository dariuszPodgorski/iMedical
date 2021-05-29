using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalApi.Models
{
    public partial class PriceListDto
    {
        public PriceListDto()
        {
            MedicalExaminations = new HashSet<MedicalExamination>();
            Visits = new HashSet<Visit>();
        }

        public int IdPriceList { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
