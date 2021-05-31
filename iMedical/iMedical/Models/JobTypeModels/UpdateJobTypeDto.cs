using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedical.Models.JobTypeModels
{
    public class UpdateJobTypeDto
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
