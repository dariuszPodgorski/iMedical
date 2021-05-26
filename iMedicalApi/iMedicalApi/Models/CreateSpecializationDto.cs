using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Models
{
    public class CreateSpecializationDto
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
