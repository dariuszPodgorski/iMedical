using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace iMedicalApi.Models
{
    public class CreatePriceListDto
    {
        public int IdPriceList { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
