using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedical.Models.TenureTypeModels
{
    public class UpdateTenureTypeDto
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
