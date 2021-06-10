using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Models
{
    public class CreateContractTypeDto
    {
        public int IdContractType { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
