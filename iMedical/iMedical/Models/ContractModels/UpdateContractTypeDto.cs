using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedical.Models.ContractModels
{
    public class UpdateContractTypeDto
    {
        [Required]
        [MaxLength(64)]

        public string Name { get; set; }
    }
}
