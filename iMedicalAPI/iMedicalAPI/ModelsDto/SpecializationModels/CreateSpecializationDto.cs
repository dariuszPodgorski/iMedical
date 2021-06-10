﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Models
{
    public class CreateContracTypeDto
    {

        public int IdSpecialization { get; set; }
        
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

    }
}
