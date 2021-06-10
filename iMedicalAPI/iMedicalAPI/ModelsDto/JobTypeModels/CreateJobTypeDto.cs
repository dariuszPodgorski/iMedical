using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Models
{
    public class CreateJobTypeDto
    {
        public int IdJobType { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
